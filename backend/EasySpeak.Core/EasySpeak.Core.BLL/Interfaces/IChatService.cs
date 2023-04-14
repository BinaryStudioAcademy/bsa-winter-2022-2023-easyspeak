using EasySpeak.Core.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatPersonDto>> GetUnreadAndLastSendMessageAsync();
        Task<List<ChatPersonDto>> GetUnreadAndLastSendMessageAsync(long id);
        Task<List<MessageGroupDto>> GetChatMessages(long chatId);
        Task<NewMessageDto> SendMessageAsync(NewMessageDto newMessageDto);
        Task<long> GetAnotherUserId(long chatId, long id);
        Task<List<ChatPersonDto>> SetMessagesAsRead(long chatId);
        Task<long> CheckIfChatExists(long firstUserId, long secondUserId);
        Task<long> CreateChat(long firstUserId, long secondUserId);
        Task<long> GetNumberOfUnreadMessages(long userId);
        Task<long[]> GetChatsById(long userId);
    }
}
