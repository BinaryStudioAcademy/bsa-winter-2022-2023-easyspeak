using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class AzureBlobStorageService : BaseService, IAzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobStorageService(BlobServiceClient blobServiceClient, EasySpeakCoreContext context, IMapper mapper) : base(context, mapper)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<UploadFileDto> AddFileAsync(NewFileDto newFileDto)
        {
            var path = await UploadFileAsync(newFileDto);

            var uploadFile = new UploadFile()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Url = path
            };

            var file = _context.Add(uploadFile).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<UploadFileDto>(file);
        }

        public async Task<UploadFileDto> GetFileAsync(long fileId)
        {
            var file = await _context.UploadFiles.FirstOrDefaultAsync((x) => x.Id == fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            return _mapper.Map<UploadFileDto>(file);
        }

        public async Task<UploadFileDto> UpdateFileAsync(long fileId, NewFileDto newFileDto)
        {
            var file = await _context.UploadFiles.FirstOrDefaultAsync((x) => x.Id == fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            string pathToNewFile = await UploadFileAsync(newFileDto);

            if (file.Url != null)
            {
                await DeleteFromBlobAsync(file, newFileDto.FolderPath);
            }

            file.Url = pathToNewFile;
            file.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return _mapper.Map<UploadFileDto>(file);
        }

        public async Task DeleteFileAsync(long fileId, string folderPath)
        {
            var file = await _context.UploadFiles.FirstOrDefaultAsync((x) => x.Id == fileId);
            if (file == null)
            {
                throw new Exception("File not found");
            }

            await DeleteFromBlobAsync(file, folderPath);

            _context.Set<UploadFile>().Remove(file);
            await _context.SaveChangesAsync();
        }

        private async Task<string> UploadFileAsync(NewFileDto newFileDto)
        {
            if (newFileDto.Stream == null)
            {
                throw new Exception($"{newFileDto.FileName} is empty");
            }

            await CreateDirectoryAsync(newFileDto.FolderPath);
            string uniqueFileName = CreateName(newFileDto.FileName, newFileDto.FolderPath);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(newFileDto.FileName, out string contentType))
            {
                throw new Exception($"{newFileDto.FileName} can not get content type");
            }

            var blob = _blobServiceClient.GetBlobContainerClient(newFileDto.FolderPath)
                .GetBlobClient(uniqueFileName);

            BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders();
            blobHttpHeaders.ContentType = contentType;

            await blob.UploadAsync(newFileDto.Stream, blobHttpHeaders);
            return blob.Uri.AbsoluteUri;
        }

        private async Task DeleteFromBlobAsync(UploadFile file, string folderPath)
        {
            var fileName = Path.GetFileName(file.Url);
            var blob = _blobServiceClient.GetBlobContainerClient(folderPath)
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
                    $"{DateTime.Now.ToString("yyyyMMddTHHmmssfff")}" +
                    $"{Path.GetExtension(fileName)}";
            }

            return fileName;
        }
    }
}
