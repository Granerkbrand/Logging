using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logging.Core
{
    public class LoggingSystem<T> : ILoggingSystem<T>
    {

        private readonly List<ILogger> _logger;

        private readonly object _lock;

        public LoggingSystemLevel LoggingLevel { get; set; } = LoggingSystemLevel.Informative;

        public LoggingSystem(ILogger[] loggers = null)
        {
            _lock = new object();
            _logger = new List<ILogger>();

            if (loggers != null)
                foreach (ILogger logger in loggers)
                    AddLogger(logger);
        }

        public void AddLogger(ILogger logger)
        {
            lock (_lock)
            {
                if (!_logger.Contains(logger))
                    _logger.Add(logger);
            }
        }

        public void RemoveLogger(ILogger logger)
        {
            lock (_lock)
            {
                if (_logger.Contains(logger))
                    _logger.Remove(logger);
            }
        }

        public void LogDebug(string message, params object[] parameters)
        {
            Log(message, LogLevel.Debug, parameters);
        }

        public void LogError(string message, params object[] parameters)
        {
            Log(message, LogLevel.Error, parameters);
        }

        public void LogInformative(string message, params object[] parameters)
        {
            Log(message, LogLevel.Informative, parameters);
        }

        public void LogSuccess(string message, params object[] parameters)
        {
            Log(message, LogLevel.Success, parameters);
        }

        public void LogVerbose(string message, params object[] parameters)
        {
            Log(message, LogLevel.Verbose, parameters);
        }

        public void LogWarning(string message, params object[] parameters)
        {
            Log(message, LogLevel.Warning, parameters);
        }

        private void Log(string message, LogLevel level, params object[] parameters)
        {
            if ((int)level > (int)LoggingLevel)
                return;

            StackFrame callStack = new StackFrame(2, true);


            LogFormat logFormat = new LogFormat()
            {
                LogLevel = level,
                Message = message,
                Parameters = parameters,
                DateTime = DateTime.Now,
                LoggedFrom = typeof(T),
                CallerInfo = new CallerInfo()
                {
                    Origin = callStack.GetMethod().Name,
                    FilePath = callStack.GetFileName(),
                    LineNumber = callStack.GetFileLineNumber()
                }
            };

            lock (_lock)
            {
                _logger.ForEach(logger => logger.Log(logFormat));
            }
        }

        public void Dispose()
        {
            for(int i = _logger.Count - 1; i >= 0; --i)
            {
                _logger[i].Flush();
                _logger.RemoveAt(i);
            }
        }
    }
}
