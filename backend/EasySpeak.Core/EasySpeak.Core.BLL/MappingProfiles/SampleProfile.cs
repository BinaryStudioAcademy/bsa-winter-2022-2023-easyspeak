using AutoMapper;
using EasySpeak.Core.Common.DTO;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.MappingProfiles
{
    public sealed class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<Sample, SampleDto>();
            CreateMap<SampleDto, Sample>();
            CreateMap<NewSampleDto, Sample>();
        }
    }
}
