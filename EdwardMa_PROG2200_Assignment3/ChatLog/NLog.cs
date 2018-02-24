using ILog;
using NLog;

namespace ChatLog
{
    public class NLog : ILoggingService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Log(string message)
        {
            logger.Log(LogLevel.Info, message);
        }
    }
}
