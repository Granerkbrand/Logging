using Logging.Core;
using Logging.Core.Output;
using Logging.Logger.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Logger
{

    public class DatabaseLogger : ILogger
    {

        public int LogThreshold { get; set; }

        public string ConnectionStringName { get; set; }

        private readonly List<LogFormat> _messages;

        private object _lock;

        public DatabaseLogger()
        {
            _messages = new List<LogFormat>();
            _lock = new object();
        }

        public void Log(LogFormat format)
        {
            lock (_lock)
            {
                _messages.Add(format);

                if (_messages.Count % LogThreshold == 0)
                    Flush();
            }
        }

        public void Flush()
        {
            lock (_lock)
            {
                using LogContext logContext = new LogContext(ConnectionStringName);
                
                while (_messages.Count > 0)
                {
                    LogFormat log = _messages[0];
                    logContext.Logs.Add(new Log()
                    {
                        LogLevel = (int)log.LogLevel,
                        Message = log.Message,
                        Parameters = log.Parameters.Select(e => new Parameter(e.Key, e.Value, e.Value.GetType())).ToList(),
                        DateTime = log.DateTime,
                        LoggedFrom = log.LoggedFrom.ToString(),
                        Origin = log.CallerInfo.Origin,
                        FilePath = log.CallerInfo.FilePath,
                        LineNumber = log.CallerInfo.LineNumber,
                        ErrorMessage = log.ErrorMessage,
                        StackTrace = log.StackTrace
                    });
                    _messages.RemoveAt(0);
                }

                logContext.SaveChanges();
            }
        }
    }
}
