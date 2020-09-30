using Logging.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core.Output
{

    public sealed class LogFormat
    {

        [JsonConverter(typeof(LogLevelConverter))]
        public LogLevel LogLevel { get; set; }

        public string Message { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public string DateTime { get; set; }

        public Type LoggedFrom { get; set; }

        public CallerInfo CallerInfo { get; set; }

        public LogFormat()
        {
            Parameters = new Dictionary<string, object>();
        }
    }
}
