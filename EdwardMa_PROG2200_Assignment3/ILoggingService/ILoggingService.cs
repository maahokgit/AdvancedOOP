namespace ILog
{
    /// <summary>
    /// Interface for logging server, enable DI
    /// </summary>
    public interface ILoggingService
    {
        void Log(string message);
    }
}