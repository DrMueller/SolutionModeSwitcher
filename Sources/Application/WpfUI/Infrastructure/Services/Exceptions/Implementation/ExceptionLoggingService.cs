using System;
using NLog;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions.Implementation
{
    public class ExceptionLoggingService : IExceptionLoggingService
    {
        private const string ErrorLogger = "ERRORS";
        private readonly Logger _logger = LogManager.GetLogger(ErrorLogger);

        public void LogException(Exception ex)
        {
            _logger.Log(LogLevel.Error, ex);
        }
    }
}