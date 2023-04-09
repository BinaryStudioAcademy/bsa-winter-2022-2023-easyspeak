using EasySpeak.RS.WebAPI.Helpers;
using EasySpeak.RS.WebAPI.Interfaces;

namespace EasySpeak.RS.WebAPI.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IDataAccessService _dataAccessService;

    public RecommendationService(IDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    public async Task AddUser(Dictionary<string, object> parameters)
    {
        try
        {
            await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.AddUserQuery, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public async Task UpdateUser(Dictionary<string, object> parameters)
    {
        await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.UpdateUserQuery, parameters);
    }
    
    public async Task RemoveTags(Dictionary<string, object> parameters) 
        => await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.RemoveTagsQuery, parameters);

    public async Task AddTags(Dictionary<string, object> parameters, List<string> parameterList)
    {
        parameters.Add("tags", parameterList);

        await RemoveTags(parameters);

        await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.AddTagsQuery, parameters);
    }

    public async Task<List<long>> GetRecommendedUsers(Dictionary<string, object> parameters)
    {
        List<long> result = new List<long>();
        try
        {
            result = await _dataAccessService
                .ExecuteWriteTransactionAsync<List<long>>(QueryHelper.GetRecommendedUsersQuery, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return result;
    }

    public async Task AddClass(Dictionary<string, object> parameters)
    {
        try
        {
            await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.AddClassQuery, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}