using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IZoomApiService
    {
        Task<ZoomMeetingLinks> GetMeetingLinks(string lessonTopic);
    }
}
