using Logging.Core;
using Logging.Core.Output;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Logger
{
    public class FileLogger : ILogger
    {

        public string Filepath { get; set; }

        public int LogThreshold { get; set; }

        private readonly List<LogFormat> _messages;

        private readonly object _messagesLock;

        public FileLogger()
        {
            Filepath = Path.Combine(Environment.CurrentDirectory, "log.txt");

            _messagesLock = new object();

            if (!File.Exists(Filepath))
            {
                File.Create(Filepath).Close();
            }

            _messages = JsonConvert.DeserializeObject<List<LogFormat>>(File.ReadAllText(Filepath)) ?? new List<LogFormat>();
        }

        public void Log(LogFormat format)
        {
            lock (_messages)
            {
                _messages.Add(format);
            }

            lock (_messages)
            {
                if (_messages.Count % LogThreshold == 0)
                    Flush();
            }
        }

        public void Flush()
        {
            lock (_messagesLock)
            {
                //TODO: logging without load and save all log messages
                File.WriteAllText(Filepath, JsonConvert.SerializeObject(_messages));
            }
        }
    }
}
