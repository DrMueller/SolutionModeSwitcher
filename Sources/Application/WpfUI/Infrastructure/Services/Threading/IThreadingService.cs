using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Threading
{
    public interface IThreadingService
    {
        void InvokeOnUiThread(Action action);
    }
}