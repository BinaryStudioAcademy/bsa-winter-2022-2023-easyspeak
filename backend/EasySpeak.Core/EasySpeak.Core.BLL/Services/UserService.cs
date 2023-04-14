using System.Net.Http.Json;
using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EasySpeak.Core.Common.Enums;
using Microsoft.Extensions.Options;
using UserShortInfoDto = EasySpeak.Core.Common.DTO.User.UserShortInfoDto;

namespace EasySpeak.Core.BLL.Services;

public class UserService : BaseService, IUserService
{
    private readonly IEasySpeakFileService _fileService;
    private readonly IFirebaseAuthService _authService;
    private readonly IHttpClientFactory _clientFactory;
    private readonly RecommendationServiceOptions _recommendationServiceOptions;
    private readonly QueriesSenderService _queriesSender;
    private readonly INotificationService _notificationService;
    
    public UserService(IEasySpeakFileService fileService, EasySpeakCoreContext context, 
            IMapper mapper, IFirebaseAuthService authService, IHttpClientFactory clientFactory,
            IOptions<RecommendationServiceOptions> recommendationServiceOptions,
            QueriesSenderService queriesSender, INotificationService notificationService) : base(context, mapper)
    {
        _authService = authService;
        _fileService = fileService;
        _clientFactory = clientFactory;
        _recommendationServiceOptions = recommendationServiceOptions.Value;
        _queriesSender = queriesSender;
        _notificationService = notificationService;
    }

    public async Task<UserDto> CreateUser(UserRegisterDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);

        _context.Users.Add(userEntity);

        await _context.SaveChangesAsync();

        void AfterMapAction(User user, UserDto dto) 
            => _queriesSender.SendAddUserQuery(user.Id, dto);

        return _mapper.Map<User, UserDto>(userEntity, opts => opts.AfterMap(AfterMapAction));
    }

    public async Task<UserDto?> GetUserAsync()
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);
        var userDto = _mapper.Map<UserDto>(user);

        if (userDto is null)
        {
            return userDto;
        }

        userDto.ImagePath = user!.EmojiName != string.Empty ? user.EmojiName : await GetProfileImageUrl(user.ImageId);

        return userDto;
    }

    public Task<bool> GetAdminStatus() => _context.Users.Where(u => u.Id == _authService.UserId).Select(u => u.IsAdmin).FirstOrDefaultAsync();

    public async Task<UserDto> AddTagsAsync(List<TagDto> tags)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId);

        var tagsNames = tags.Select(x => x.Name).ToList();

        user!.Tags = await _context.Tags.Where(t => tagsNames.Contains(t.Name)).ToListAsync();

        await _context.SaveChangesAsync();
        
        _queriesSender.SendAddTagsQuery(user.Id, tags);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter)
    {
        var users = _context.Users
            .Include(u => u.Tags)
            .Include(u => u.Image)
            .Where(u =>
                !_context.Friends.Any(f =>
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
        if (filter.Tags is not null && filter.Tags.Any())
        {
            filteredUsers = filteredUsers.Where(u => u.Tags.Any(t => filter.Tags.Select(t=>t.Id).Contains(t.Id)));
        }


        var filteredUsersList = await filteredUsers.ToListAsync();

        return await AddCompatibility(filteredUsersList, filter.Compatibility);
    }

    private async Task<List<UserShortInfoDto>> AddCompatibility(List<User> users, int compatibility)
    {
        var compatabilityInformation =
            await GetRecommendedUsers(compatibility, users.Select(x => x.Id).ToList());
        
        var compatibleUsers = users.Where(x => compatabilityInformation.ContainsKey(x.Id)).Select(x => x).ToList();
        
        var result = _mapper.Map<List<UserShortInfoDto>>(compatibleUsers);
        
        foreach (var user in result)
        {
            user.Compatibility = compatabilityInformation[user.Id];
        }

        return result;
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

        var user = _context.Users.SingleOrDefault(u => u.Id == userId) ??
                   throw new ArgumentException($"Failed to find the user with id {userId}");
        var lesson = _context.Lessons.SingleOrDefault(l => l.Id == lessonId) ??
                     throw new ArgumentException($"Failed to find the lesson with id {lessonId}");

        user.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        await _notificationService.AddNotificationAsync(NotificationType.classJoin, lesson.Id);

        void AfterMapAction(Lesson o, LessonDto dto) => dto.SubscribersCount = _context.Lessons
            .Select(t => new { Id = t.Id, SbCount = t.Subscribers.Count })
            .FirstOrDefault(l => l.Id == lessonId)!.SbCount;

        return _mapper.Map<Lesson, LessonDto>(lesson, options => options.AfterMap(AfterMapAction));
    }

    public async Task<string> UploadEmojiAvatar(string emojiName)
    {
        var user = await GetCurrentUser();

        if(user.ImageId is not null)
        {
            await _fileService.DeleteFileAsync((long)user.ImageId);

            user.ImageId = null;
            await _context.SaveChangesAsync();
        }
         
        user.EmojiName = emojiName;
        await _context.SaveChangesAsync();

        return user.EmojiName;
    }

    public async Task<string> UploadProfilePhoto(IFormFile file)
    {
        var user = await GetCurrentUser();

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

        user.EmojiName = string.Empty;
        user.ImageId = uploadFileDto.Id;
        profilePhoto.UserId = user.Id;
        await _context.SaveChangesAsync();

        return profilePhoto.Url;
    }

    private async Task<User> GetCurrentUser()
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == _authService.UserId) 
            ?? throw new ArgumentNullException("This user not found");
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

        userDto.Id = user.Id;
        userDto.IsAdmin = user.IsAdmin;

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
                dtoTags => dtoTags.Id,
                dbTags => dbTags.Id,
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

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    private async Task<Dictionary<long, long>> GetRecommendedUsers(int compatibility, List<long> filteredUsers)
    {
        var recommendationRequestBody = new NewRecommendationDto()
        {
            Compatibility = compatibility,
            Id = _authService.UserId,
            Users = filteredUsers
        };

        var client = _clientFactory.CreateClient("RecommendationClient");

        var response = await client.PostAsJsonAsync(_recommendationServiceOptions.Host + "/recommendation",
            recommendationRequestBody);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Dictionary<long, long>>() ?? new();

    }

    public async Task<long> GetUserIdByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user is null ? 0 : user.Id;

    }

    public async Task<List<UserShortInfoDto>> GetFriends()
    {
        var friendshipsWithUsers = _context.Friends.Include(f => f.User).ThenInclude(user => user.Image).Include(f => f.Requester);
        var users = await friendshipsWithUsers
           .Where(f => f.FriendshipStatus != FriendshipStatus.Rejected && (f.UserId == _authService.UserId || f.RequesterId == _authService.UserId))
           .Select(f => f.UserId == _authService.UserId ? f.Requester : f.User)
           .ToListAsync();

        var mappedFriends = _mapper.Map<List<UserShortInfoDto>>(users);

        mappedFriends.ForEach(friend => friend.ImagePath = users.First(user => user.Id == friend.Id).Image?.Url ?? string.Empty);

        await FillUserFriendshipStatus(mappedFriends);

        return mappedFriends;
    }
}
