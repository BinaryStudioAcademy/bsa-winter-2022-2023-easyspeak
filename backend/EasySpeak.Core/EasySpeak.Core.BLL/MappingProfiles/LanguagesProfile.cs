using AutoMapper;
using EasySpeak.Core.BLL.Converters.Enum;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class LanguagesProfile : Profile
{
    public LanguagesProfile()
    {
        CreateMap<Language, string>().ConvertUsing<EnumToStringConverter<Language>>();
        CreateMap<string, Language>().ConvertUsing<StringToEnumConverter<Language>>();
    }
}