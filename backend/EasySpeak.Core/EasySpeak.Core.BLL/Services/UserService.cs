﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace EasySpeak.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public UserService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService firebaseAuthService) :
            base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<LessonDto> EnrollUserToLesson(long lessonId)
        {
            var userId = _firebaseAuthService.UserId;

            var user = _context.Users.SingleOrDefault(u => u.Id == userId) ?? throw new ArgumentException($"Failed to find the user with id {userId}");
            var lesson = _context.Lessons.SingleOrDefault(l => l.Id == lessonId) ?? throw new ArgumentException($"Failed to find the lesson with id {lessonId}");

            user.Lessons.Add(lesson);

            await _context.SaveChangesAsync();

            void AfterMapAction(Lesson o, LessonDto dto) => dto.SubscribersCount = _context.Lessons
                .Select(t => new { Id = t.Id, SbCount = t.Subscribers.Count })
                .FirstOrDefault(l => l.Id == lessonId)!.SbCount;

            return _mapper.Map<Lesson, LessonDto>(lesson, options => options.AfterMap(AfterMapAction));
        }

        public async Task<UserDto> GetUserAsync()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _firebaseAuthService.UserId);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter)
        {
            var users = _context.Users.Include(u => u.Tags);

            IQueryable<User> filteredUsers = users;

            if(userFilter.Language is not null)
            {
                var enumLanguage = _mapper.Map<Language>(userFilter.Language);
                filteredUsers = filteredUsers.Where(u => u.Language == enumLanguage);
            }
            if(userFilter.LangLevels is not null && userFilter.LangLevels.Length != 0)
            {
                var eLevels = userFilter.LangLevels.Select(c => _mapper.Map<LanguageLevel>(c));
                filteredUsers = filteredUsers.Where(u => eLevels.Contains(u.LanguageLevel));
            }
            if(userFilter.Topics is not null && userFilter.Topics.Length != 0)
            {
                filteredUsers = filteredUsers.Where(u => u.Tags.Any(t => userFilter.Topics.Contains(t.Name)));
            }
            return await filteredUsers.ProjectTo<UserShortInfoDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
