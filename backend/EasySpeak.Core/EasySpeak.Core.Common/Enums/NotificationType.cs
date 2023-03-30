using System.ComponentModel;

namespace EasySpeak.Core.Common.Enums
{
    public enum NotificationType
    {
        [Description("Text notification")] Information = 1,
        [Description("Action notification")] WithAction
    }
}
