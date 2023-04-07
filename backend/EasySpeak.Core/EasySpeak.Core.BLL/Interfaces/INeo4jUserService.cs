using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces;

public interface INeo4jUserService
{
    Task AddUser(int id, UserDto user);

    Task UpdateUser(int id, UserDto user);
    Task AddClass(int id, LessonDto lesson);
    Task RemoveTags(Dictionary<string, object> userParams);
    Task AddTags(int id, List<TagDto> tags);
    Task<List<int>> GetRecommendedUsers(int id, int compability);
}