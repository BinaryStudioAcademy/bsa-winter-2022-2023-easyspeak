using EasySpeak.Core.Common.DTO.User;
using EasySpeak.RS.WebAPI.Interfaces;
using EasySpeak.RS.WebAPI.Options;
using Microsoft.Extensions.Options;
using Neo4j.Driver;

namespace EasySpeak.RS.WebAPI.Services;

public class DataAccessService : IDataAccessService
{
    private readonly IAsyncSession _session;

    public DataAccessService(IDriver driver, IOptions<RecommendationServiceOptions> options)
    {
        _session = driver.AsyncSession(o => o.WithDatabase(options.Value.Database));
    }

    public async Task<T> ExecuteWriteTransactionAsync<T>(string query, IDictionary<string, object>? parameters = null)
    {
        parameters = parameters == null ? new Dictionary<string, object>() : parameters;
    
        var result = await _session.ExecuteWriteAsync(async tx =>
        {
            var res = await tx.RunAsync(query, parameters);
    
            var response = (await res.SingleAsync())[0].As<T>();
    
            return response;
        });
    
        return result;
    }

    public async Task ExecuteWriteActionAsync(string query, IDictionary<string, object>? parameters = null)
    {
        parameters = parameters == null ? new Dictionary<string, object>() : parameters;

        await _session.ExecuteWriteAsync(async tx => await tx.RunAsync(query, parameters));
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await _session.CloseAsync();
        GC.SuppressFinalize(this);
    }
}