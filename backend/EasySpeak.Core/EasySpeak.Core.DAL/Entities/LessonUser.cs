namespace EasySpeak.Core.DAL.Entities;

public class LessonUser
{
    public long SubscribersId { get; set; }
    
    public long LessonsId { get; set; }

    public LessonUser(long subscribersId, long lessonsId)
    {
        LessonsId = lessonsId;
        SubscribersId = subscribersId;
    }
}