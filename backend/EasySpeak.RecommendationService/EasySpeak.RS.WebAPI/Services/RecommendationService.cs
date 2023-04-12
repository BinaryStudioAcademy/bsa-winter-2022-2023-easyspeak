using EasySpeak.Core.Common.DTO.User;
using EasySpeak.RS.WebAPI.Helpers;
using EasySpeak.RS.WebAPI.Interfaces;
using Neo4j.Driver;

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

    public async Task AddTags(Dictionary<string, object> parameters, string[] parameterList)
    {
        parameters.Add("tags", parameterList);

        await RemoveTags(parameters);

        await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.AddTagsQuery, parameters);
    }

    public async Task<Dictionary<long, long>> GetRecommendedUsers(Dictionary<string, object> parameters)
    {
        Dictionary<long, long> result = new();
        try
        {
            var users = await _dataAccessService
                .ExecuteWriteTransactionAsync<List<object>>(QueryHelper.GetRecommendedUsersQuery, parameters);
            
            foreach (var record in users)
            {
                var values = record.As<List<object>>();
                result.Add((long)values[0], (long)values[1]);
            }
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
            await _dataAccessService.ExecuteWriteActionAsync(QueryHelper.StartClassQuery, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}