using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions
{
    public interface IExceptionHandlingService
    {
        void HandledAction(Action action);

        Task HandledActionAsync(Func<Task> action, Action finallyAction = null);

        T HandledFunction<T>(Func<T> func);

        Task<T> HandledFunctionAsync<T>(Func<Task<T>> func);
    }
}