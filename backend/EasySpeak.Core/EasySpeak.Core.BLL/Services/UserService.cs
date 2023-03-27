using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;

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
            var user = _context.Users
                .Single(p => p.Id == _firebaseAuthService.UserId);

            Lesson existingLesson = _context.Lessons
                .Single(p => p.Id == lessonId);

            user.Lessons.Add(existingLesson);

            await _context.SaveChangesAsync();

            return _mapper.Map<LessonDto>(existingLesson, options => options.AfterMap((o, dto) =>
                  dto.SubscribersCount = _context.Lessons.Select(t => new { Id = t.Id, SbCount = t.Subscribers.Count })
                      .Single(l => l.Id == lessonId).SbCount));
        }
    }
}
