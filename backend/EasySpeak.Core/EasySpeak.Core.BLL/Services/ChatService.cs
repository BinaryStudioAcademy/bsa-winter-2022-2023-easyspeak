﻿using AutoMapper;
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
                         .Where(chat => chat.Users.Any(user => user.Id ==  _firebaseAuthService.UserId))
                         .Include(chat => chat.Messages)
                         .Select(chat => new ChatPersonDto
                         {
                             Email = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).Email,
                             FirstName = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).FirstName,
                             LastName = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).LastName,
                             LastMessageDate = chat.Messages.Any() ? chat.Messages.Max(message => message.CreatedAt) : null,
                             IsRead = chat.Messages.Any() ? chat.Messages.Any(message => !message.IsRead) : null,
                             LastMessage = chat.Messages.Any() ? chat.Messages.OrderBy(message => message.CreatedAt).Last().Text : string.Empty,
                             NumberOfUnreadMessages = chat.Messages.Any() ? chat.Messages.Count(message => !message.IsRead && message.CreatedBy != _firebaseAuthService.UserId) : null,
                             ChatId = chat.Id,
                             ImageUrl = chat.Users.First(user => user.Id != _firebaseAuthService.UserId).Image.Url?? string.Empty
                         })
                         .OrderByDescending(entity => entity.LastMessageDate)
                         .ToListAsync();
        }

        public async Task<List<ChatPersonDto>> GetUnreadAndLastSendMessageAsync(long id)
        {
            return await _context.Chats
                         .Include(chat => chat.Users)
                         .Where(chat => chat.Users.Any(user => user.Id == id))
                         .Include(chat => chat.Messages)
                         .Select(chat => new ChatPersonDto
                         {
                             Email = chat.Users.First(user => user.Id != id).Email,
                             FirstName = chat.Users.First(user => user.Id != id).FirstName,
                             LastName = chat.Users.First(user => user.Id != id).LastName,
                             LastMessageDate = chat.Messages.Any() ? chat.Messages.Max(message => message.CreatedAt) : null,
                             IsRead = chat.Messages.Any() ? chat.Messages.Any(message => !message.IsRead) : null,
                             LastMessage = chat.Messages.Any() ? chat.Messages.OrderBy(message => message.CreatedAt).Last().Text : string.Empty,
                             NumberOfUnreadMessages = chat.Messages.Any() ? chat.Messages.Count(message => !message.IsRead && message.CreatedBy != id) : null,
                             ChatId = chat.Id,
                             ImageUrl = chat.Users.First(user => user.Id != id).Image.Url ?? string.Empty
                         })
                         .OrderByDescending(entity => entity.LastMessageDate)
                         .ToListAsync();
        }

        public async Task<List<MessageGroupDto>> GetChatMessages(long chatId)
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
                                        CreatedBy = message.CreatedBy,
                                        IsRead = message.IsRead,
                                        Text = message.Text,
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

        public async Task<long> GetAnotherUserId(long chatId, long id)
        {
           var chat = await _context.Chats.Include(chat => chat.Users).FirstOrDefaultAsync(chat => chat.Id == chatId);

            if (chat is null)
                return 0;

            return chat.Users.First(user => user.Id != id).Id;
        }

        public async Task<List<ChatPersonDto>> SetMessagesAsRead(long chatId)
        {
            var currentChat = await _context.Chats.Include(chat => chat.Messages.Where(message => !message.IsRead))
                .FirstOrDefaultAsync(chat => chat.Id == chatId);

            if (currentChat is null)
                return new List<ChatPersonDto>();

            currentChat.Messages
                .Where(message => message.CreatedBy != _firebaseAuthService.UserId)
                .ToList()
                .ForEach(message => message.IsRead = true);

            _context.Chats.Update(currentChat);

            await _context.SaveChangesAsync();

            return await GetUnreadAndLastSendMessageAsync(_firebaseAuthService.UserId);
        }

        public async Task<long> CheckIfChatExists(long firstUserId, long secondUserId)
        {
            var chat = await _context.Chats
                .Include(c => c.Users)
                .Where(c => c.Users.Any(u => u.Id == firstUserId))
                .FirstOrDefaultAsync(c => c.Users.Any(u => u.Id == secondUserId));
            return chat?.Id ?? 0;
        }

        public async Task<long> CreateChat(long firstUserId, long secondUserId)
        {
            Chat chat = new Chat();

            chat.Users.Add(await _context.Users.FirstAsync(user => user.Id == firstUserId));

            chat.Users.Add(await _context.Users.FirstAsync(user => user.Id == secondUserId));

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<long> GetNumberOfUnreadMessages(long userId)
        {
            return await _context.Chats
                .Include(chat => chat.Users)
                .Where(chat => chat.Users.Any(user => user.Id == userId))
                .Include(chat => chat.Messages)
                .SelectMany(chat => chat.Messages)
                .CountAsync(message => message.CreatedBy != userId && !message.IsRead);
        }

        public async Task<long[]> GetChatsById(long userId)
        {
            return await _context.Chats
                .Where(chat => chat.Users.Any(user => user.Id == userId))
                .Select(chat => chat.Id)
                .ToArrayAsync();
        }
    }
}
