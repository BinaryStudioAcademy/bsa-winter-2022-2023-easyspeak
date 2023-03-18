namespace EasySpeak.Core.DAL.Entities;

public class TagUser
{
    public long TagsId { get; set; }
    public long UsersId { get; set; }
    public TagUser(long usersId, long tagsId)
    {
        UsersId = usersId;
        TagsId = tagsId;
    }
}