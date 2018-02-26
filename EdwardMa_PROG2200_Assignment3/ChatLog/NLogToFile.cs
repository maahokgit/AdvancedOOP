using NLog;

namespace ChatLog
{
    public class NLogToFile : ILoggingService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Log(string message)
        {
            logger.Log(LogLevel.Info, message);
        }
    }
}