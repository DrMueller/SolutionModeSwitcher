using System;
using System.Collections.Generic;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions
{
    public interface IExceptionConfigurationService
    {
        IReadOnlyCollection<Action<Exception>> ExceptionCallbacks { get; }

        void AddExceptionCallback(Action<Exception> exceptionCallback);
    }
}