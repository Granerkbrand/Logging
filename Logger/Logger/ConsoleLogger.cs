using Logging.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Logging.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Flush()
        {

        }

        public void Log(LogFormat format)
        {

            Regex regex = new Regex(@"\b*{\w+}\b*");
            var matches = regex.Matches(format.Message);

            StringBuilder @string = new StringBuilder(format.Message);

            if (matches.Count == format.Parameters.Length)
            {
                for (int i = 0; i < matches.Count; ++i)
                {
                    Match match = matches[i];
                    @string.Remove(match.Index, match.Value.Length);
                    @string.Insert(match.Index, format.Parameters[i]);
                }
            }

            Console.WriteLine($"[{format.DateTime:yyyy-MM-dd hh:mm:ss}] {@string}");
        }
    }
}
