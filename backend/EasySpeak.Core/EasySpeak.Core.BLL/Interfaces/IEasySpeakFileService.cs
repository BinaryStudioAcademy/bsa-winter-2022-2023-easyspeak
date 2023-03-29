using EasySpeak.Core.Common.DTO.UploadFile;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IEasySpeakFileService
    {
        Task<EasySpeakFileDto> AddFileAsync(NewEasySpeakFileDto newFileDto);
        Task<EasySpeakFileDto> GetFileAsync(long fileId);
        Task<EasySpeakFileDto> UpdateFileAsync(long fileId, NewEasySpeakFileDto newFileDto);
        Task DeleteFileAsync(long fileId);
    }
}
