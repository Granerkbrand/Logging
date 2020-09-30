using Logging.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core
{
    public sealed class CallerInfo
    {
        public string Origin { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
    }

    public sealed class LogFormat
    {

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
