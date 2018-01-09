using System.Collections.Generic;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.MainNavigation.Initialization
{
    public interface IMainNavigationInitializingService
    {
        IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries();

        void NavigateToMainEntryPoint();
    }
}