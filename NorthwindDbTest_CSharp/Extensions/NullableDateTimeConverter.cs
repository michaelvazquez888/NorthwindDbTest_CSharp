using Newtonsoft.Json;
using System;

namespace NorthwindDbTest_CSharp.Extensions
{
    public class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.Value);
            }

            else
            {
                writer.WriteNull();
            }
        }

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null || reader.TokenType == JsonToken.String && reader.Value.ToString().ToUpper() == "NULL" || reader.Value == null)
            {
                return null;
            }

            return DateTime.Parse(reader.Value.ToString());
        }
    }
}