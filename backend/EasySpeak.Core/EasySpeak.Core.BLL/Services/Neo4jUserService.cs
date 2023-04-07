using Bogus.DataSets;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Lesson;
using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.DTO.User;
using EasySpeak.Core.DAL.Entities;
using Neo4j.Driver;

namespace EasySpeak.Core.BLL.Services;

public class Neo4jUserService : INeo4jUserService
{
    private readonly INeo4jDataAccessService _dataAccessService;

    public Neo4jUserService(INeo4jDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    public async Task AddUser(int id, UserDto user)
    {
        var parameters = user.ToDictionary();
        
        parameters.Add("id", id);

        await _dataAccessService.ExecuteWriteActionAsync(Neo4jQueriesHelper.AddUserQuery, parameters);
    }

    public async Task UpdateUser(int id, UserDto user)
    {
        var parameters = user.ToDictionary();
        
        parameters.Add("id", id);
        
        await _dataAccessService.ExecuteWriteActionAsync(Neo4jQueriesHelper.UpdateUserQuery, parameters);
    }
    
    public async Task RemoveTags(Dictionary<string, object> userParams) 
        => await _dataAccessService.ExecuteWriteActionAsync(Neo4jQueriesHelper.RemoveTagsQuery, userParams);

    public async Task AddTags(int id, List<TagDto> tags)
    {
        var tagsParameters = tags.Select(x => x.Name).ToList();
        
        var parameters = new Dictionary<string, object>()
        {
            {"id", id}
        };

        await RemoveTags(parameters);
        
        parameters.Add("tags", tagsParameters);

        await _dataAccessService.ExecuteWriteActionAsync(Neo4jQueriesHelper.AddTagsQuery, parameters);
    }

    public async Task<List<int>> GetRecommendedUsers(int id, int compability)
    {
        var parameters = new Dictionary<string, object>()
        {
            {"id", id},
            {"compability", compability}
        };
        
        return await _dataAccessService
            .ExecuteWriteTransactionAsync<List<int>>(Neo4jQueriesHelper.GetRecommendedUsersQuery, parameters);
    }

    public async Task AddClass(int id, LessonDto lesson)
    {
        var parameters = new Dictionary<string, object>()
        {
            {"id", id},
            {"className", lesson.Name }
        };
        
        await _dataAccessService.ExecuteWriteActionAsync(Neo4jQueriesHelper.AddClassQuery, parameters);
    }
}