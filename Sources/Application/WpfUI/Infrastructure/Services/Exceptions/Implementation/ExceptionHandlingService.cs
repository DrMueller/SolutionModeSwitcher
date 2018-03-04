using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions.Implementation
{
    public class ExceptionHandlingService : IExceptionHandlingService
    {
        private readonly IExceptionConfigurationService _excpetionConfigurationService;
        private readonly IExceptionLoggingService _logger;

        public ExceptionHandlingService(IExceptionLoggingService logger, IExceptionConfigurationService exceptionHandlerConfigurationService)
        {
            _logger = logger;
            _excpetionConfigurationService = exceptionHandlerConfigurationService;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General exception handler")]
        public void HandledAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                HandleException(ex);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General exception handler")]
        public async Task HandledActionAsync(Func<Task> action, Action finallyAction = null)
        {
            try
            {
                await action();
            }
            catch (OperationCanceledException)
            {
                // Nothing to do
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                finallyAction?.Invoke();
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General exception handler")]
        public T HandledFunction<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "General exception handler")]
        public async Task<T> HandledFunctionAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var result = await func();
                return result;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return default(T);
            }
        }

        private void HandleException(Exception ex)
        {
            foreach (var cb in _excpetionConfigurationService.ExceptionCallbacks)
            {
                cb.Invoke(ex);
            }

            _logger.LogException(ex);
        }
    }
}