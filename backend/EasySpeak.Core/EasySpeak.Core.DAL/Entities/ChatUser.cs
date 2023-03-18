namespace EasySpeak.Core.DAL.Entities;

public class ChatUser
{
    public long ChatsId { get; set; }
    
    public long UsersId { get; set; }

    public ChatUser(long usersId, long chatsId)
    {
        UsersId = usersId;
        ChatsId = chatsId;
    }
}