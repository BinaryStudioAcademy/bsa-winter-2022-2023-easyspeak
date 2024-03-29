﻿using EasySpeak.Core.Common.DTO.Tag;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.Common.DTO.Lesson;

public class LessonDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? MediaPath { get; set; }
    public DateTime StartAt { get; set; }
    public int? LimitOfUsers { get; set; }
    public string? LanguageLevel { get; set; }
    public int SubscribersCount { get; set; }
    public string? YoutubeVideoId { get; set; } 
    public string? ZoomMeetingLink { get; set; }
    public string? ZoomMeetingLinkHost { get; set; }
    public bool isSubscribed { get; set; }
    public bool isCanceled { get; set; }

    public UserForLessonDto? User { get; set; }
    public ICollection<TagForLessonDto>? Tags { get; set; }
    public string Questions { get; set; } = string.Empty;

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {"classId", Id},
            {"className", Name}
        };
    }
}