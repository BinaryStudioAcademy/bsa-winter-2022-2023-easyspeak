using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Message;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class ChatService : BaseService, IChatService
    {
        private readonly IFirebaseAuthService _firebaseAuthService;

        public ChatService(EasySpeakCoreContext context, IMapper mapper, IFirebaseAuthService firebaseAuthService) : base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<List<ChatPersonDto>> GetUnreadAndLastSendMessageAsync()
        {
            return await _context.Chats
                         .Include(chat => chat.Users)
                         .Where(chat => chat.Users.Any(user => user.Id == _firebaseAuthService.UserId))
                         .Include(chat => chat.Messages)
                         .Select(chat => new
                         {
                             Date = chat.Messages.Max(message => message.CreatedAt),
                             IsRead = chat.Messages.Any(message => !message.IsRead),
                             Value = new ChatPersonDto
                             {
                                 FirstName = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).FirstName,
                                 LastName = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).LastName,
                                 LastMessage = chat.Messages.OrderBy(message => message.CreatedBy).Last().Text,
                                 NumberOfUnreadMessages = chat.Messages.Count(message => !message.IsRead)
                             }
                         })
                           .OrderByDescending(entity => entity.IsRead ? 0 : 1)
                           .ThenByDescending(entity => entity.Date)
                           .Select(entity => entity.Value)
                           .ToListAsync();
        }

        public async Task<List<MessageGroupDto>> GetChatMessages(int chatId)
        {
            var currentChat = await _context.Chats.Include(chat => chat.Messages)
                                            .FirstOrDefaultAsync(chat => chat.Id == chatId);

            var result = new List<MessageGroupDto>();

            if (currentChat != null)
            {
                result = currentChat.Messages
                        .GroupBy(test => test.CreatedAt.Date)
                        .Take(20)
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
                        .OrderByDescending(groupMessages => groupMessages.Date)
                        .ToList();
            }

            return result;
        }
    }
}
