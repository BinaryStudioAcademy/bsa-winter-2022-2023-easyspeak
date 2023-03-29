using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class EasySpeakFileService : BaseService, IEasySpeakFileService
    {
        private readonly IAzureBlobStorageService _azureService;

        public EasySpeakFileService(IAzureBlobStorageService azureService, EasySpeakCoreContext context, IMapper mapper) : base(context, mapper) 
        {
            _azureService = azureService;
        }

        public async Task<EasySpeakFileDto> AddFileAsync(NewEasySpeakFileDto newFileDto)
        {
            var path = await _azureService.UploadFileAsync(newFileDto);

            var uploadFile = new EasySpeakFile()
            {
                Url = path
            };

            var file = _context.Add(uploadFile).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<EasySpeakFileDto>(file);
        }

        public async Task<EasySpeakFileDto> GetFileAsync(long fileId)
        {
            var file = await _context.EasySpeakFiles.FirstOrDefaultAsync((x) => x.Id == fileId);
            if (file == null)
            {
                throw new ArgumentNullException("File not found");
            }

            return _mapper.Map<EasySpeakFileDto>(file);
        }

        public async Task<EasySpeakFileDto> UpdateFileAsync(long fileId, NewEasySpeakFileDto newFileDto)
        {
            await DeleteFileAsync(fileId);
            var file = await AddFileAsync(newFileDto);

            return file;
        }

        public async Task DeleteFileAsync(long fileId)
        {
            var file = await _context.EasySpeakFiles.FirstOrDefaultAsync((x) => x.Id == fileId);
            if (file == null)
            {
                throw new ArgumentNullException("File not found");
            }

            await _azureService.DeleteFromBlobAsync(file);

            _context.Set<EasySpeakFile>().Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
