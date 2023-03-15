using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        private EasySpeakCoreContext _context;
        public FirebaseAuthService(EasySpeakCoreContext context)
        {
            _context = context;
        }
        public long UserId { get; private set; }
        
        
        public async Task SetUserId(string email)
        {
            var user =  _context.Users
                .Where(user => user.Email == email)
                .FirstOrDefault();

            if (user != null)
            {
                UserId = user.Id;
            }
        }
    }
}
