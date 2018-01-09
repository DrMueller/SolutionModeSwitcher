using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions
{
    public interface IExceptionLoggingService
    {
        void LogException(Exception ex);
    }
}