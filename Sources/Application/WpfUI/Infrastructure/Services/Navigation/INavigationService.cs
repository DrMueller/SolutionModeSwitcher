using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<T>()
            where T : TopLevelViewModelBase;

        void NavigateTo(TopLevelViewModelBase target);
    }
}