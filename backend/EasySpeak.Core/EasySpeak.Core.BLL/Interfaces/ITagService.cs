using EasySpeak.Core.Common.DTO.Tag;

namespace EasySpeak.Core.BLL.Interfaces;

public interface ITagService
{
    Task<TagDto[]> GetAllTags();
}