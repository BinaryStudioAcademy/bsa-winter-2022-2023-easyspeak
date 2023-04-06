using EasySpeak.Core.Common.DTO.Filter;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.User;
using Microsoft.AspNetCore.Http;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserRegisterDto userDto);
        Task<UserDto> AddTagsAsync(List<TagDto> tags);
        Task<LessonDto> EnrollUserToLesson(long lessonId);
        Task<List<UserShortInfoDto>> GetFilteredUsers(UserFilterDto userFilter);
        Task<UserDto?> GetUserAsync();
        Task<bool> GetAdminStatus();
        Task<string> UploadProfilePhoto(IFormFile file);
        Task<TagDto[]> GetUserTags();
        Task<UserDto> UpdateUser(UserDto userDto);
        Task<UserDto> MakeAdminAsync(int userId);
    }
}
