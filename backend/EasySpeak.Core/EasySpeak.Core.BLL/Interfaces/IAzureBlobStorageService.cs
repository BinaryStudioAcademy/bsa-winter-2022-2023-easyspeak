using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadFileAsync(NewEasySpeakFileDto newFileDto);
        Task DeleteFromBlobAsync(EasySpeakFile file);
    }
}
