using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Message;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EasySpeak.Core.BLL.Services
{
    public class ChatService : BaseService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;
        public ChatService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService firebaseAuthService) : base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<ICollection<ChatPersonDto>> GetUnreadAndLastSendMessageAsync() =>
            await _context.Chats.Where(chat => chat.Users
            .FirstOrDefault(user => user.Id == _firebaseAuthService.UserId) != null 
            && chat.Messages.Any(message => message.IsRead == false))
            .Select(chat =>
                        new ChatPersonDto
                        {
                            Name = chat.Users
                            .First(user => user.Id == _firebaseAuthService.UserId).FirstName + " " + chat.Users
                            .First(user => user.Id == _firebaseAuthService.UserId).LastName,
                            LastMessage = chat.Messages.Last(message => message.IsRead == false).Text,
                            NumberOfUnreadMessages = (uint)chat.Messages.Count(message => message.IsRead == false)
                        })
                .ToListAsync();

        //public async Task<ICollection<MessageGroupDto>> GetMessagesInChat(int chatId) =>
        //    await _context.Chats.FirstOrDefault(chat => chat.Id == chatId)?.Messages
        //    .Select(message => 
        //                    new MessageGroupDto
        //                    {
        //                        Messages = 
        //                    }
        //    )
    }
}
