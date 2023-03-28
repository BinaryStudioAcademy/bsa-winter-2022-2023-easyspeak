using AutoMapper;
using EasySpeak.Core.BLL.Converters.Enum;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.BLL.MappingProfiles;

public class TimezonesProfile: Profile
{
    public TimezonesProfile()
    {
        CreateMap<Timezone, string>().ConvertUsing<EnumToStringConverter<Timezone>>();
        CreateMap<string, Timezone>().ConvertUsing<StringToEnumConverter<Timezone>>();
    }
}