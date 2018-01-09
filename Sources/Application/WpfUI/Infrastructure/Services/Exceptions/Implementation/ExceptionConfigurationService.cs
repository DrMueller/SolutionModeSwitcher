using System;
using System.Collections.Generic;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions.Implementation
{
    public class ExceptionConfigurationService : IExceptionConfigurationService
    {
        private readonly List<Action<Exception>> _exceptionCallbacks = new List<Action<Exception>>();
        public IReadOnlyCollection<Action<Exception>> ExceptionCallbacks => _exceptionCallbacks;

        public void AddExceptionCallback(Action<Exception> exceptionCallback)
        {
            _exceptionCallbacks.Add(exceptionCallback);
        }
    }
}