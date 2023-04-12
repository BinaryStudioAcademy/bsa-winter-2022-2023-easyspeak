using EasySpeak.Core.Common.DTO.User;

namespace EasySpeak.RS.WebAPI.Interfaces;

public interface IRecommendationService
{
    Task AddUser(Dictionary<string, object> parameters);
    Task UpdateUser(Dictionary<string, object> parameters);
    Task AddClass(Dictionary<string, object> parameters);
    Task RemoveTags(Dictionary<string, object> parameters);
    Task AddTags(Dictionary<string, object> parameters, string[] parameterList);
    Task<Dictionary<long, long>> GetRecommendedUsers(Dictionary<string, object> parameters);
    
}