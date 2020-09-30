using Logging.Core.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Core
{
    public interface ILogger
    {
        void Log(LogFormat format);

        void Flush();
    }
}
