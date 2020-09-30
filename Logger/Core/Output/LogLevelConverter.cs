using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core.Output
{
    public class LogLevelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(LogLevel), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Enum.GetName(typeof(LogLevel), value));
        }
    }
}
