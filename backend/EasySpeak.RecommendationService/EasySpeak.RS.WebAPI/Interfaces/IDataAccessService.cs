using EasySpeak.Core.Common.DTO.User;

namespace EasySpeak.RS.WebAPI.Interfaces;

public interface IDataAccessService : IAsyncDisposable
{
    Task<T> ExecuteWriteTransactionAsync<T>(string query, IDictionary<string, object>? parameters = null);

    Task ExecuteWriteActionAsync(string query, IDictionary<string, object>? parameters = null);
}