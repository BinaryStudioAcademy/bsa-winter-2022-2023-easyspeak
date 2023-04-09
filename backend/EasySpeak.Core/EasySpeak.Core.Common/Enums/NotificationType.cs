using System.ComponentModel;

namespace EasySpeak.Core.Common.Enums
{
    public enum NotificationType
    {
        [Description("Accepted friendship request")] friendshipAcception = 1,
        [Description("Group class join")] classJoin,
        [Description("New friendship request")] friendshipRequest,
        [Description("Lesson reminding")] reminding
    }
}
