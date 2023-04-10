using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.BLL.Services;

public class UserService : BaseService, IUserService
{
    private readonly IEasySpeakFileService _fileService;
    private readonly IFirebaseAuthService _authService;
    private readonly INotificationService _notificationService;

    public UserService(IEasySpeakFileService fileService, EasySpeakCoreContext context, IMapper mapper,
        IFirebaseAuthService authService, INotificationService notificationService) 
        : base(context, mapper)
    {
        _authService = authService;
        _fileService = fileService;
        _notificationService = notificationService;
    }

    public async Task<UserDto> CreateUser(UserRegisterDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);

        _context.Users.Add(userEntity);

        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(userEntity);
    }

    public async Task<UserDto?> GetUserAsync()
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);
        var userDto = _mapper.Map<UserDto>(user);

        if (userDto is null)
        {
            return userDto;
        }

        userDto.ImagePath = await GetProfileImageUrl(user!.ImageId);

        return userDto;
    }

    public Task<bool> GetAdminStatus() => _context.Users.Where(u => u.Id == _authService.UserId).Select(u => u.IsAdmin).FirstOrDefaultAsync();

    public async Task<UserDto> AddTagsAsync(List<TagDto> tags)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);

        var tagsNames = tags.Select(x => x.Name).ToList();

        user!.Tags = await _context.Tags.Where(t => tagsNames.Contains(t.Name)).ToListAsync();

        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter)
    {
        var users = _context.Users
            .Include(u => u.Tags)
            .Include(u => u.Image)
            .Where(u => 
                !_context.Friends.Any(f=>
                    (f.UserId == _authService.UserId || f.RequesterId == _authService.UserId)
                    && (f.UserId == u.Id || f.RequesterId == u.Id)
                    && f.FriendshipStatus != FriendshipStatus.Rejected)
                && u.Id != _authService.UserId
            );
        var filter = _mapper.Map<UserFilter>(userFilter);

        IQueryable<User> filteredUsers = users;

        if (filter.Language is not null)
        {
            filteredUsers = filteredUsers.Where(u => u.Language == filter.Language);
        }
        if (filter.LangLevels is not null && filter.LangLevels.Any())
        {
            filteredUsers = filteredUsers.Where(u => filter.LangLevels.Contains(u.LanguageLevel));
        }
        if (filter.Topics is not null && filter.Topics.Any())
        {
            filteredUsers = filteredUsers.Where(u => u.Tags.Any(t => filter.Topics.Contains(t.Name)));
        }
        var filteredUsersList = await filteredUsers.ToListAsync();
        return _mapper.Map<List<UserShortInfoDto>>(filteredUsersList);
    }

    private async Task FillUserFriendshipStatus(List<UserShortInfoDto> users)
    {
        var myId = _authService.UserId;
        var friends = await _context.Friends.Where(f => f.FriendshipStatus != FriendshipStatus.Rejected && (f.RequesterId == myId || f.UserId == myId)).ToListAsync();
        users.ForEach(user =>
        {
            if (friends.Any(requester => requester.RequesterId == user.Id && requester.FriendshipStatus == FriendshipStatus.Pending))
            {
                user.UserFriendshipStatus = UserFriendshipStatus.Requester;
            }
            else if (friends.Any(acceptor => acceptor.UserId == user.Id && acceptor.FriendshipStatus == FriendshipStatus.Pending))
            {
                user.UserFriendshipStatus = UserFriendshipStatus.Acceptor;
            }
            else
            {
                user.UserFriendshipStatus = UserFriendshipStatus.Friend;
            }
        });
    }

    public async Task<LessonDto> EnrollUserToLesson(long lessonId)
    {
        var userId = _authService.UserId;

        var user = _context.Users.SingleOrDefault(u => u.Id == userId) ?? throw new ArgumentException($"Failed to find the user with id {userId}");
        var lesson = _context.Lessons.SingleOrDefault(l => l.Id == lessonId) ?? throw new ArgumentException($"Failed to find the lesson with id {lessonId}");

        user.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        await _notificationService.AddNotificationAsync(NotificationType.classJoin, lesson.Id);

        void AfterMapAction(Lesson o, LessonDto dto) => dto.SubscribersCount = _context.Lessons
            .Select(t => new { Id = t.Id, SbCount = t.Subscribers.Count })
            .FirstOrDefault(l => l.Id == lessonId)!.SbCount;

        return _mapper.Map<Lesson, LessonDto>(lesson, options => options.AfterMap(AfterMapAction));
    }

    public async Task<string> UploadProfilePhoto(IFormFile file)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);

        if (user == null)
        {
            throw new ArgumentNullException("This user not found");
        }

        var fileDto = new NewEasySpeakFileDto()
        {
            Stream = file.OpenReadStream(),
            FileName = file.FileName
        };

        var uploadFileDto = await _fileService.AddFileAsync(fileDto);
        var profilePhoto = await _context.EasySpeakFiles.FirstOrDefaultAsync(f => f.Id == uploadFileDto.Id);

        if (profilePhoto == null || profilePhoto.Url == null)
        {
            throw new ArgumentNullException("This file not found");
        }

        user.ImageId = uploadFileDto.Id;
        profilePhoto.UserId = user.Id;
        await _context.SaveChangesAsync();

        return profilePhoto.Url;
    }

    private async Task<string> GetProfileImageUrl(long? imageId)
    {
        var profileImage = await _context.EasySpeakFiles.FirstOrDefaultAsync(f => f.Id == imageId);
        return profileImage?.Url ?? "";
    }

    public async Task<TagDto[]> GetUserTags()
    {
        var userId = _authService.UserId;

        // get users tags
        var userTags = _context.Tags.Where(t => t.Users.Any(u => u.Id == userId));

        // get all tags DTO
        var allTagsTdo = await _context.Tags.Select(t => _mapper.Map<Tag, TagDto>(t)).ToArrayAsync();

        // form needed data
        return allTagsTdo.Select(tagDto =>
        {
            tagDto.IsSelected = userTags.Any(x => x.Id == tagDto.Id);
            return tagDto;
        }).ToArray();
    }

    public async Task<UserDto> UpdateUser(UserDto userDto)
    {
        var userId = _authService.UserId;
        var user = await _context.Users.Include(u => u.Tags).FirstOrDefaultAsync(a => a.Id == userId) ?? throw new ArgumentException($"Failed to find the user with id {userId}");

        _mapper.Map(userDto, user, opt => opt.AfterMap(SetUserTags));

        await _context.SaveChangesAsync();

        return _mapper.Map<User, UserDto>(user);
    }

    private void SetUserTags(UserDto dtoUser, User dbUser)
    {
        if (dtoUser.Tags != null)
        {
            dbUser.Tags = dtoUser.Tags.Join(
                _context.Tags,
                dtoTags => dtoTags.Name,
                dbTags => dbTags.Name,
                (_, dbTags) => dbTags).ToList();
        }
    }

    public async Task<UserDto> MakeAdminAsync(int userId)
    {
        var user = await _context.Users.Where(u => u.Id == userId).SingleOrDefaultAsync();
        if (user is not null)
        {
            user.IsAdmin = true;
            await _context.SaveChangesAsync();
        }
        UserDto userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<long> GetUserIdByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user=>user.Email == email);
        return user is null ? 0 : user.Id;

    }

    public async Task<List<UserShortInfoDto>> GetFriends()
    {
        var friendshipsWithUsers = _context.Friends.Include(f => f.User).Include(f => f.Requester);
        var users = await friendshipsWithUsers
           .Where(f => f.FriendshipStatus != FriendshipStatus.Rejected && (f.UserId == _authService.UserId || f.RequesterId == _authService.UserId))
           .Select(f => f.UserId == _authService.UserId ? f.Requester : f.User)
           .ToListAsync();

        var mappedFriends = _mapper.Map<List<UserShortInfoDto>>(users);

        await FillUserFriendshipStatus(mappedFriends);

        return mappedFriends;
    }
}
