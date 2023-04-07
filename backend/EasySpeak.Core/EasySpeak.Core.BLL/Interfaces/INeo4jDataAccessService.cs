namespace EasySpeak.Core.BLL.Interfaces;

public interface INeo4jDataAccessService : IAsyncDisposable
{
    Task<T> ExecuteWriteTransactionAsync<T>(string query, IDictionary<string, object>? parameters = null);

    Task ExecuteWriteActionAsync(string query, IDictionary<string, object>? parameters = null);

    Task<List<T>> ExecuteReadTransactionAsync<T>(string query, string returnObjectKey,
        IDictionary<string, object>? parameters);
}