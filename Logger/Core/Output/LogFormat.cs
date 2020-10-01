using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Logging.Core.Output
{

    public sealed class LogFormat
    {

        [JsonConverter(typeof(LogLevelConverter))]
        public LogLevel LogLevel { get; set; }

        public string Message { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public DateTime DateTime { get; set; }

        public Type LoggedFrom { get; set; }

        public CallerInfo CallerInfo { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public LogFormat()
        {
            Parameters = new Dictionary<string, object>();
        }


        [JsonIgnore]
        public static JsonSerializerSettings SerializerSettings => new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
