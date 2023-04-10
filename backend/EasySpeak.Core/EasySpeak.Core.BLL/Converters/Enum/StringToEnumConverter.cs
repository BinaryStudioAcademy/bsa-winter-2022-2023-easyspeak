using AutoMapper;
using EasySpeak.Core.BLL.Helpers;
using EasySpeak.Core.BLL.MappingProfiles;
using EasySpeak.Core.Common.Enums;

namespace EasySpeak.Core.BLL.Converters.Enum;

public class StringToEnumConverter<T> : ITypeConverter<string, T> 
    where T : System.Enum
{
    public T Convert(string source, T destination, ResolutionContext context)
    {
        var country = System.Enum.GetValues(typeof(T))
            .Cast<T>()
            .FirstOrDefault(c => EnumMappingHelper<T>.GetDescription(c) == source);
              
        if (country == null || country.ToString() == "0")
        {
            throw new ArgumentException($"Invalid country description: {source}");
        }
                
        return country;
    }
    
}