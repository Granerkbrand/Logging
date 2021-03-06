﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core
{
    public interface ILoggingSystem<T> : IDisposable
    {

        LoggingSystemLevel LoggingLevel { get; set; }

        void AddLogger(ILogger logger);

        void RemoveLogger(ILogger logger);

        void LogSuccess(string message, params object[] parameters);
        void LogSuccess(string message, params (string, object)[] parameters);
        void LogWarning(string message, params object[] parameters);
        void LogWarning(string message, params (string, object)[] parameters);
        void LogError(string message, params object[] parameters);
        void LogError(string message, params (string, object)[] parameters);
        void LogError(string message, Exception exception, params object[] parameters);
        void LogError(string message, Exception exception, params (string, object)[] parameters);
        void LogInformative(string message, params object[] parameters);
        void LogInformative(string message, params (string, object)[] parameters);
        void LogVerbose(string message, params object[] parameters);
        void LogVerbose(string message, params (string, object)[] parameters);
        void LogDebug(string message, params object[] parameters);
        void LogDebug(string message, params (string, object)[] parameters);

    }
}
