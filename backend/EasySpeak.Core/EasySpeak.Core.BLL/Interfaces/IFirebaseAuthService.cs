namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IFirebaseAuthService
    {
        long UserId { get; }
        Task SetUserId(string email);
    }
}
