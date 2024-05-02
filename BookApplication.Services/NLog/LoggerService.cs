using NLog;

namespace BookApplication.Services.NLog
{
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public async Task LogDebug(string message) => _logger.Debug(message);


        public async Task LogError(string message) => _logger.Error(message);    

        public async Task LogInfo(string message)
        {
            _logger.Info(message);
        }

        public async Task LogWarning(string message)
        {
           _logger.Warn(message);
        }
    }
}
