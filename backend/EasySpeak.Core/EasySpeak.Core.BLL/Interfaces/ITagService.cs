namespace EasySpeak.Core.BLL.Interfaces;

public interface ITagService
{
    Task<string[]> GetAllTagNames();
}