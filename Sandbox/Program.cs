using Logging.Core;
using Logging.Logger;
using System;

namespace Sandbox
{
    class Program
    {
        static void Main()
        {
            using ILoggingSystem<Program> loggingSystem = new LoggingSystem<Program>()
            {
                LoggingLevel = LoggingSystemLevel.Debug
            };

            loggingSystem.AddLogger(new ConsoleLogger());
            loggingSystem.AddLogger(new FileLogger()
            {
                LogThreshold = 1000
            });

            for(int i = 0; i < 1000; ++i)
            {
                loggingSystem.LogInformative("Test with {value} and Name {nickname} and double {value}", i, $"Max the {i}.");
            }
            loggingSystem.LogInformative("This is a {logtype} log", "great");


            loggingSystem.LogError("This is a {adjective} Error. Please contact {contact}", ("contact", "fatal"), ("adjective", "nobody"));
        }
    }
}
