using EasySpeak.Core.DAL.Entities;
using System.Net.Http.Headers;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IZoomApiService
    {
        Task<ZoomMeetingLinks> GetMeetingLinks(string lessonTopic);
    }
}
