using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Message;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EasySpeak.Core.BLL.Services
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public ChatService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService firebaseAuthService) : base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<ICollection<ChatPersonDto>> GetUnreadAndLastSendMessageAsync()
        {
            return await _context.Chats
             .Include(chat => chat.Messages)
             .Include(chat => chat.Users)
             .Where(chat => chat.Users
             .Any(user => user.Id == _firebaseAuthService.UserId))
             .AsEnumerable()
             .Select(chat => {
                 var user = chat.Users.First(user => user.Id != _firebaseAuthService.UserId);
                 return new 
                 {
                     Date = chat.Messages.Max(message => message.CreatedAt),
                     IsRead = chat.Messages.Select(message => message.IsRead),
                     Value = new ChatPersonDto
                     {
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         LastMessage = chat.Messages.Last().Text,
                         NumberOfUnreadMessages = chat.Messages.Count(message => !message.IsRead)
                     }
                 };
             })
            .OrderByDescending(entity => entity.IsRead)
            .OrderByDescending(entity => entity.Date)
            .Select(entity => entity.Value)
            .AsQueryable()
            .ToListAsync();
        }

        public async Task<List<MessageGroupDto>> GetChatMessages(int chatId)
        {
            var currentChat = await _context.Chats.Include(chat => chat.Messages)
                                            .FirstOrDefaultAsync(chat => chat.Id == chatId);

            var result = new List<MessageGroupDto>();

            if (currentChat != null)
            {
                result = await currentChat.Messages
                        .GroupBy(test => test.CreatedAt.Date)
                        .Take(20)
                        .OrderByDescending(groupMessages => groupMessages.Key)
                        .Select(groupedMessages => new MessageGroupDto
                        {
                            Date = groupedMessages.Key,
                            Messages = groupedMessages
                                    .Select(message => new MessageDto
                                    {
                                        ChatId = message.ChatId,
                                        UserId = message.CreatedBy,
                                        Message = message.Text,
                                        CreatedAt = message.CreatedAt,
                                    })
                        })
                        .AsQueryable()
                        .ToListAsync();
            }

            return result;
        }
    }
}
