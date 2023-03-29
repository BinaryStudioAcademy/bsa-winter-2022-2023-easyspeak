using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;
        private readonly IEasySpeakFileService _fileService;

        public UserService(IEasySpeakFileService fileService, EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService firebaseAuthService) :
            base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
            _fileService = fileService;
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

        public async Task<string> UploadProfilePhoto(IFormFile file)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _firebaseAuthService.UserId);

            if (user == null)
            {
                throw new Exception("This user not found");
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
                throw new Exception("This file not found");
            }

            user.ImageId = uploadFileDto.Id;
            profilePhoto.UserId = user.Id;
            await _context.SaveChangesAsync();

            return profilePhoto.Url;
        }
    }
}
