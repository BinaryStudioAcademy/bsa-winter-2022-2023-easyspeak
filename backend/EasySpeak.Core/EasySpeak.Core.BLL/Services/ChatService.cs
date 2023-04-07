using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
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
                         .Select(chat => new ChatPersonDto
                         {
                             FirstName = chat.Users.FirstOrDefault(user => user.Id != _firebaseAuthService.UserId).FirstName,
                             LastName = chat.Users.FirstOrDefault(user => user.Id != _firebaseAuthService.UserId).LastName,
                             Date = chat.Messages.Count() != 0 ? chat.Messages.Max(message => message.CreatedAt) : null,
                             IsRead = chat.Messages.Count() != 0 ? chat.Messages.Any(message => !message.IsRead) : null,
                             LastMessage = chat.Messages.Count() != 0 ? chat.Messages.OrderBy(message => message.CreatedBy).Last().Text : string.Empty,
                             NumberOfUnreadMessages = chat.Messages.Count() != 0 ? chat.Messages.Count(message => !message.IsRead) : null,
                             ChatId = chat.Id,
                         })
                         //.OrderByDescending(entity => entity.IsRead ? 0 : 1)
                         //.ThenByDescending(entity => entity.Date)
                         .ToListAsync();
        }

        public async Task<List<MessageGroupDto>> GetChatMessages(int chatId)
        {
            var currentChat = await _context.Chats.Include(chat => chat.Messages)
                                            .FirstOrDefaultAsync(chat => chat.Id == chatId);

            if (currentChat is null)
            {
                return new List<MessageGroupDto>();
            }

            var result = currentChat.Messages
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
                                        IsRead = message.IsRead,
                                        Message = message.Text,
                                        CreatedAt = message.CreatedAt,
                                    })
                        })
                        .OrderBy(groupMessages => groupMessages.Date)
                        .ToList();

            return result;
        }

        public async Task<NewMessageDto> SendMessageAsync(NewMessageDto newMessageDto)
        {
            var messageEntity = _mapper.Map<Message>(newMessageDto);

            _context.Messages.Add(messageEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<NewMessageDto>(messageEntity);
        }
    }
}
