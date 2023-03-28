using EasySpeak.Core.Common.DTO.User;
using Microsoft.AspNetCore.Http;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);
        Task UploadProfilePhoto(IFormFile file, long userId);
    }
}
