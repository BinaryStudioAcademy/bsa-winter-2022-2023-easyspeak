namespace EasySpeak.RS.WebAPI.Interfaces;

public interface IRecommendationService
{
    Task AddUser(Dictionary<string, object> parameters);
    Task UpdateUser(Dictionary<string, object> parameters);
    Task AddClass(Dictionary<string, object> parameters);
    Task RemoveTags(Dictionary<string, object> parameters);
    Task AddTags(Dictionary<string, object> parameters, List<string> parameterList);
    Task<List<long>> GetRecommendedUsers(Dictionary<string, object> parameters);
}