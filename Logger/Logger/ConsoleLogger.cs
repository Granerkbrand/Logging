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
            StringBuilder @string = new StringBuilder(format.Message);

            if (format.Parameters.Count == format.Parameters.Count)
            {
                foreach (var parameter in format.Parameters)
                {
                    @string.Replace($"{{{parameter.Key}}}", $"{parameter.Value}");
                }
            }

            Console.WriteLine($"[{format.DateTime}] {@string}");
        }
    }
}
