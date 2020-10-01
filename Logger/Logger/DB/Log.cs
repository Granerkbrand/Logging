using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logging.Logger.DB
{
    public class Log
    {

        [Key]
        public int ID { get; set; }

        public int LogLevel { get; set; }

        public string Message { get; set; }

        public ICollection<Parameter> Parameters { get; set; }

        public DateTime DateTime { get; set; }

        public string LoggedFrom { get; set; }

        public string Origin { get; set; }

        public string FilePath { get; set; }

        public int LineNumber { get; set; }

        public string ErrorMessage { get; set; }

        public string StackTrace { get; set; }

        public Log()
        {
            Parameters = new List<Parameter>();
        }

    }
}
