using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.BLL.Options;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.StaticFiles;

namespace EasySpeak.Core.BLL.Services
{
    public class AzureBlobStorageService : BaseService, IAzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerOptions _blobContainerOptions;

        public AzureBlobStorageService(BlobContainerOptions blobContainerOptions, 
            BlobServiceClient blobServiceClient, 
            EasySpeakCoreContext context, 
            IMapper mapper) : base(context, mapper)
        {
            _blobServiceClient = blobServiceClient;
            _blobContainerOptions = blobContainerOptions;
        }

        public async Task<string> UploadFileAsync(NewEasySpeakFileDto newFileDto)
        {
            if (newFileDto.Stream == null)
            {
                throw new ArgumentNullException($"{newFileDto.FileName} is empty");
            }

            await CreateDirectoryAsync(_blobContainerOptions.BlobContainerName);
            string uniqueFileName = CreateName(newFileDto.FileName, _blobContainerOptions.BlobContainerName);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(newFileDto.FileName, out string contentType))
            {
                throw new ArgumentNullException($"{newFileDto.FileName} can not get content type");
            }

            var blob = _blobServiceClient.GetBlobContainerClient(_blobContainerOptions.BlobContainerName)
                .GetBlobClient(uniqueFileName);

            BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders();
            blobHttpHeaders.ContentType = contentType;

            await blob.UploadAsync(newFileDto.Stream, blobHttpHeaders);
            return blob.Uri.AbsoluteUri;
        }

        public async Task DeleteFromBlobAsync(EasySpeakFile file)
        {
            var fileName = Path.GetFileName(file.Url);
            var blob = _blobServiceClient.GetBlobContainerClient(_blobContainerOptions.BlobContainerName)
                .GetBlobClient(fileName);
            await blob.DeleteIfExistsAsync();
        }

        private async Task CreateDirectoryAsync(string folderPath)
        {
            if (!_blobServiceClient.GetBlobContainerClient(folderPath).Exists())
            {
                await _blobServiceClient.CreateBlobContainerAsync(folderPath);
            }
        }

        private string CreateName(string fileName, string folderPath)
        {
            var blob = _blobServiceClient.GetBlobContainerClient(folderPath).GetBlobClient(fileName);

            if (blob.Exists())
            {
                return $"{Path.GetFileNameWithoutExtension(fileName)}_" +
                    $"{Guid.NewGuid()}" +
                    $"{Path.GetExtension(fileName)}";
            }

            return fileName;
        }
    }
}
