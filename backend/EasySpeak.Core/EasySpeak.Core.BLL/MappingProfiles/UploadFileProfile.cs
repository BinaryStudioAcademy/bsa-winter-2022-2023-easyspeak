using AutoMapper;
using EasySpeak.Core.Common.DTO.UploadFile;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles
{
    public class UploadFileProfile : Profile
    {
        public UploadFileProfile()
        {
            CreateMap<EasySpeakFile, EasySpeakFileDto>();
            CreateMap<EasySpeakFileDto, EasySpeakFile>();
        }
    }
}
