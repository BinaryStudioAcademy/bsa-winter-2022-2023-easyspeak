using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private readonly EasySpeakCoreContext _context;
        public FirebaseAuthService(EasySpeakCoreContext context)
        {
            _context = context;
        }
        public long UserId { get; private set; }
        public string Email { get; private set; }
        
        public async Task SetUserId(string email)
        {
            var user =  await _context.Users
                .FirstOrDefaultAsync(user => user.Email == email);

            if (user != null)
            {
                UserId = user.Id;
                Email = user.Email;
            }
        }
    }
}
