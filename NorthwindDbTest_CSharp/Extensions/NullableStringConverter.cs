using Newtonsoft.Json;
using System;

public class NullableStringConverter : JsonConverter<string>
{
    public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
    {
        if (string.IsNullOrEmpty(value))
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteValue(value);
        }
    }

    public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null || reader.TokenType == JsonToken.String && reader.Value.ToString().ToUpper() == "NULL" || reader.Value == null)
        {
            return null;
        }

        return reader.Value.ToString();
    }
}
