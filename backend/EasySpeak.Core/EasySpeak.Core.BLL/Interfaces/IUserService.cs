using EasySpeak.Core.Common.DTO.User;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);
        Task<List<UserShortInfoDto>> GetFilteredUsers(string? language = null, string[]? country = null, string[]? interests = null, int? compatibility = null);
    }
}
