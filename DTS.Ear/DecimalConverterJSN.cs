using System;
using System.Buffers.Text;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DTS.Ear
{
    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetDecimal(out decimal value))
                {
                    return value;
                }

                if (reader.TryGetInt32(out int intValue))
                {
                    return intValue;
                }

                if (reader.TryGetInt64(out long longValue))
                {
                    return longValue;
                }

                if (reader.TryGetDouble(out double doubleValue))
                {
                    return (decimal)doubleValue;
                }

               
            }

            throw new JsonException("Unable to parse decimal value.");
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}