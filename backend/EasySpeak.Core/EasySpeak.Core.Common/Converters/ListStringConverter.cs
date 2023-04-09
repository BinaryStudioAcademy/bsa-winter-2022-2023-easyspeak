using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasySpeak.Core.Common.Converters;

public class ListStringConverter : JsonConverter<List<string>>
{
    public override List<string> ReadJson(JsonReader reader, Type objectType, List<string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JArray jsonArray = JArray.Load(reader);
        return jsonArray.ToObject<List<string>>() ?? new List<string>();
    }

    public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
    {
        if (value != null)
        {
            JArray jsonArray = JArray.FromObject(value);
            jsonArray.WriteTo(writer);
        }
    }
}