using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.User;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);
        Task<UserDto> AddTagsAsync(List<TagDto> tags);
        Task<UserDto> GetUserAsync();
    }
}
