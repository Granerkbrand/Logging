using Logging.Core;
using Logging.Core.Output;
using Logging.Logger.Helper;
using System;
using System.Text;

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

            Console.ForegroundColor = format.LogLevel.GetConsoleColor();
            Console.WriteLine($"[{format.DateTime}] {format.LogLevel.GetName(), -11}: {@string}");
            Console.ResetColor();
        }
    }
}
