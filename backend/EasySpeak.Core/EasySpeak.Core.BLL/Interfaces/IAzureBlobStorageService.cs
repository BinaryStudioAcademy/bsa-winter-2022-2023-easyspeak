using EasySpeak.Core.Common.DTO.UploadFile;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<UploadFileDto> AddFileAsync(NewFileDto newFileDto);
        Task<UploadFileDto> GetFileAsync(long fileId);
        Task<UploadFileDto> UpdateFileAsync(long fileId, NewFileDto newFileDto);
        Task DeleteFileAsync(long fileId, string folderPath);
    }
}
