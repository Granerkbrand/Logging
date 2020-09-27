using Logging.Core;
using Logging.Logger;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main()
        {
            using ILoggingSystem<Program> loggingSystem = new LoggingSystem<Program>();

            loggingSystem.AddLogger(new ConsoleLogger());
            loggingSystem.AddLogger(new FileLogger()
            {
                LogThreshold = 1000
            });

            loggingSystem.LoggingLevel = LoggingSystemLevel.Debug;

            for(int i = 0; i < 1000; ++i)
            {
                loggingSystem.LogInformative("Test with {value}", i);
            }
            loggingSystem.LogInformative("Das ist der {logtype} log", "Abschluss");
        }
    }
}
