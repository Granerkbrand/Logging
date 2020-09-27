using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core
{
    /// <summary>
    /// Specifies the level of the log message
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logs a success
        /// </summary>
        Success = 1,

        /// <summary>
        /// Logs an warning
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Logs an error
        /// </summary>
        Error = 3,

        /// <summary>
        /// Logs general information
        /// </summary>
        Informative = 4,

        /// <summary>
        /// Logs deteiled information
        /// </summary>
        Verbose = 5,

        /// <summary>
        /// Logs debug information
        /// </summary>
        Debug = 6,
    }
}
