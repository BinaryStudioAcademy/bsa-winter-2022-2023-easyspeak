﻿using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);

        Task<LessonDto> EnrollUserToLesson(long lessonId);

        Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter);

        Task<UserDto> GetUserAsync();
    }
}
