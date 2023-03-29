using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IEasySpeakFileService _fileService;
        public UserService(EasySpeakCoreContext context, IMapper mapper, IEasySpeakFileService fileService) : base(context, mapper)
        {
            _fileService = fileService;
        }

        public async Task<UserDto> CreateUser(UserRegisterDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);

            _context.Users.Add(userEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<UserProfilePhotoDto> UploadProfilePhoto(IFormFile file, long userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

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

            if (profilePhoto == null)
            {
                throw new Exception("This file not found");
            }

            user.ImageId = uploadFileDto.Id;
            profilePhoto.UserId = userId;
            await _context.SaveChangesAsync();

            var photoDto = _mapper.Map<UserProfilePhotoDto>(user);
            photoDto.PhotoUrl = uploadFileDto.Url;

            return photoDto;
        }
    }
}
