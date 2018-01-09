using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<T>()
            where T : ViewModelBase;

        void NavigateTo(ViewModelBase target);
    }
}