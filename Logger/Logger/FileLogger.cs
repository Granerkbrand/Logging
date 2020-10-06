using Logging.Core;
using Logging.Core.Output;
using Logging.Logger.FileUtils;
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

        public string Basepath { get; set; }

        public FileTimeSpan FileTimeSpan { get; set; } = FileTimeSpan.INFINITY;

        public int LogThreshold { get; set; }

        private readonly List<LogFormat> _messages;

        private readonly object _messagesLock;

        public FileLogger(string basepath = null)
        {
            Basepath = basepath;
            string filepath = Path.Combine(basepath ?? Environment.CurrentDirectory, $"log{FileTimeSpan.GetDateTimeString()}.txt");

            _messagesLock = new object();

            if (File.Exists(filepath))
            {
                _messages = JsonConvert.DeserializeObject<List<LogFormat>>(File.ReadAllText(filepath), LogFormat.SerializerSettings) ?? new List<LogFormat>();
            }
            else
            {
                _messages = new List<LogFormat>();
            }
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
                string filepath = Path.Combine(Basepath ?? Environment.CurrentDirectory, $"log{FileTimeSpan.GetDateTimeString()}.txt");

                //TODO: logging without load and save all log messages
                File.WriteAllText(filepath, JsonConvert.SerializeObject(_messages, LogFormat.SerializerSettings));
            }
        }
    }
}
