using EasySpeak.Core.Common.DTO.Message;
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
        Task<List<MessageGroupDto>> GetChatMessages(int chatId);
    }
}
