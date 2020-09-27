using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core
{
    /// <summary>
    /// The Level of the Factory
    /// </summary>
    public enum LoggingSystemLevel
    {
        /// <summary>
        /// Logs nothing
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Logs error, warning and success messages
        /// </summary>
        Error = 3,

        /// <summary>
        /// Logs all general Messages
        /// </summary>
        Informative = 4,

        /// <summary>
        /// Logs more details
        /// </summary>
        Verbose = 5,

        /// <summary>
        /// Logs everything
        /// </summary>
        Debug = 6,
    }
}
