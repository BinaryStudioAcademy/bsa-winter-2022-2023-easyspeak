using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Neo4j.Driver;

namespace EasySpeak.Core.BLL.Services;

public class Neo4JDataAccessService : INeo4jDataAccessService
{
    private IAsyncSession _session;

    public Neo4JDataAccessService(IDriver driver, IOptions<Neo4jOptions> options)
        {
            _session = driver.AsyncSession(o => o.WithDatabase(options.Value.Neo4jDatabase));
            
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
        
        public async Task<List<T>> ExecuteReadTransactionAsync<T>(string query, string returnObjectKey, IDictionary<string, object>? parameters)
        {
            parameters = parameters == null ? new Dictionary<string, object>() : parameters;

            var result = await _session.ExecuteReadAsync(async tx =>
            {
                var res = await tx.RunAsync(query, parameters);

                var records = await res.ToListAsync();

                var response = records.Select(x => (T)x.Values[returnObjectKey]).ToList();

                return response;
            });

            return result;
        }
        
        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            await _session.CloseAsync();
        }
}