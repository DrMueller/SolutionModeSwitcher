using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Threading.Implementation
{
    public class ThreadingService : IThreadingService
    {
        public void InvokeOnUiThread(Action action)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(action);
        }
    }
}