using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<int> EnrollUserToLesson(long userId, long lessonId)
        {
            var user = _context.Users
                .Include(p => p.Lessons)
                .Single(p => p.Id == userId);

            var existingLesson = _context.Lessons
                .Single(p => p.Id == lessonId);

            user.Lessons.Add(existingLesson);

            return await _context.SaveChangesAsync();
        }
    }
}
