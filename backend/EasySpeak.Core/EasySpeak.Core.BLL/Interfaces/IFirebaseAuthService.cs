namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IFirebaseAuthService
    {
        long UserId { get; }
        string Email { get; }
        Task SetUserId(string email);
    }
}
