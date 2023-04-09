﻿using System.Net.Http.Json;
using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Rabbit;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.Common.Options;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasySpeak.Core.BLL.Services;

public class UserService : BaseService, IUserService
{
    private readonly IEasySpeakFileService _fileService;
    private readonly IFirebaseAuthService _authService;
    private readonly IMessageProducer _messageProducer;
    private readonly RabbitQueuesOptions _rabbitQueues;
    private readonly IHttpClientFactory _clientFactory;
    
    
    public UserService(IEasySpeakFileService fileService, EasySpeakCoreContext context, 
            IMapper mapper, IFirebaseAuthService authService, IMessageProducer messageProducer,
            IOptions<RabbitQueuesOptions> rabbitQueues, IHttpClientFactory clientFactory)
        : base(context, mapper)
    {
        _authService = authService;
        _fileService = fileService;
        _messageProducer = messageProducer;
        _rabbitQueues = rabbitQueues.Value;
        _clientFactory = clientFactory;
    }

    public async Task<UserDto> CreateUser(UserRegisterDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);

        _context.Users.Add(userEntity);

        await _context.SaveChangesAsync();

        void AfterMapAction(User user, UserDto dto) => SendAddUserQuery(user.Id, dto);

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

        SendAddTagsQuery(user.Id, tags);

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
        if (filter.Compatibility is not null)
        {
            var compatibleUsers =
                await GetRecommendedUsers((int)filter.Compatibility, filteredUsers.Select(x => x.Id).ToList());
            filteredUsers = filteredUsers.Where(x => compatibleUsers.Contains(x.Id));
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

        var user = _context.Users.SingleOrDefault(u => u.Id == userId) ??
                   throw new ArgumentException($"Failed to find the user with id {userId}");
        var lesson = _context.Lessons.SingleOrDefault(l => l.Id == lessonId) ??
                     throw new ArgumentException($"Failed to find the lesson with id {lessonId}");

        user.Lessons.Add(lesson);

        await _context.SaveChangesAsync();

        void AfterMapAction(Lesson o, LessonDto dto)
        {
            dto.SubscribersCount = _context.Lessons
                .Select(t => new {Id = t.Id, SbCount = t.Subscribers.Count})
                .FirstOrDefault(l => l.Id == lessonId)!.SbCount;
        }

        var lessonDto = _mapper.Map<Lesson, LessonDto>(lesson, options => options.AfterMap(AfterMapAction));
        
        SendAddClassQuery(_authService.UserId, lessonDto);

        return lessonDto;
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

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
    
    private void SendAddUserQuery(long id, UserDto user)
    {
        var queryParams = new RecommendationServiceMessageDto()
        {
            Type = QueryType.AddUser,
            Parameters = user.ToDictionary()
        };
        
        queryParams.Parameters.Add("id", id);
        
        SendQueryToRabbit(queryParams);
    }

    private void SendAddTagsQuery(long id, List<TagDto> tags)
    {

        var queryParams = new RecommendationServiceMessageDto()
        {
            Type = QueryType.AddTags,
            Parameters = new Dictionary<string, object>()
            {
                {"id", id}
            },
            ParameterList = tags.Select(x => x.Name).ToList()
        };

        SendQueryToRabbit(queryParams);
    }

    private void SendAddClassQuery(long id, LessonDto lesson)
    {
        var queryParams = new RecommendationServiceMessageDto()
        {
            Type = QueryType.AddClass,
            Parameters = lesson.ToDictionary()
        };
        
        queryParams.Parameters.Add("id", id);

        SendQueryToRabbit(queryParams);
    }
    
    private void SendQueryToRabbit(RecommendationServiceMessageDto data)
    {
        _messageProducer.Init(_rabbitQueues.RecommendationQueue, "");
        _messageProducer.SendMessage(data);
    }

    private async Task<List<long>> GetRecommendedUsers(int compatibility, List<long> filteredUsers)
    {
        var recommendationRequestBody = new NewRecommendationDto()
        {
            Compatibility = compatibility,
            Id = _authService.UserId,
            Users = filteredUsers
        };

        var client = _clientFactory.CreateClient("RecommendationClient");

        var response = await client.PostAsJsonAsync("http://localhost:5110/recommendation", recommendationRequestBody);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<long>>() ?? new List<long>();

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
