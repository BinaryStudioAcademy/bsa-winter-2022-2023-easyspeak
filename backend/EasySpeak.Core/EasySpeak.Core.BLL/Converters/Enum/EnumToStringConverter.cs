using System.ComponentModel;
using AutoMapper;

namespace EasySpeak.Core.BLL.Converters.Enum;

public class EnumToStringConverter<T> : ITypeConverter<T, string> 
    where T : System.Enum
{
    public string Convert(T source, string destination, ResolutionContext context)
    {
        var type = source.GetType();
        var member = type.GetMember(source.ToString());

        var attributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        
        if (!attributes.Any())
        {
            throw new ArgumentException($"Cannot convert {nameof(source)} because it doesn't provide" +
                                        $" description attribute with friendly name");
        }
        

        return ((DescriptionAttribute)attributes.ElementAt(0)).Description;
    }
}