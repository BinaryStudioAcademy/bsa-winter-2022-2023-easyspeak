using AutoMapper;
using EasySpeak.Core.BLL.Converters.Enum;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class CountriesProfile : Profile
{
    public CountriesProfile()
    {
        CreateMap<Country, string>().ConvertUsing<EnumToStringConverter<Country>>();
        CreateMap<string, Country>().ConvertUsing<StringToEnumConverter<Country>>();
    }
}
