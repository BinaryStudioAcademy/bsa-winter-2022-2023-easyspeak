namespace EasySpeak.Core.DAL.Entities;

public class LessonTag
{
    public long LessonsId { get; set; }
    
    public long TagsId { get; set; }

    public LessonTag(long lessonsId, long tagsId)
    {
        LessonsId = lessonsId;
        TagsId = tagsId;
    }
}