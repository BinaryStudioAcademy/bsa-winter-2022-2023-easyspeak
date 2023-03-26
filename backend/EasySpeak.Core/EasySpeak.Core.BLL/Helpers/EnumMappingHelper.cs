using System.ComponentModel;

namespace EasySpeak.Core.BLL.Helpers;

public static class EnumMappingHelper<T> where T : Enum
{
    public static string GetDescription(T source)
    {
        var field = source.GetType().GetField(source.ToString());
        var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;
        
        return attribute?.Description ?? source.ToString();
    }
}