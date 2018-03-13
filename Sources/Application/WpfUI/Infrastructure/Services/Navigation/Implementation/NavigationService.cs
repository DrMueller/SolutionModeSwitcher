using Mmu.Sms.WpfUI.Infrastructure.Extensions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel.Factories;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly INavigationConfigurationService _navigationHandlerConfiguration;
        private readonly ITopLevelViewModelFactory _topLevelViewModelFactory;

        public NavigationService(INavigationConfigurationService navigationHandlerConfiguration, ITopLevelViewModelFactory topLevelViewModelFactory)
        {
            _navigationHandlerConfiguration = navigationHandlerConfiguration;
            _topLevelViewModelFactory = topLevelViewModelFactory;
        }

        public void NavigateTo<T>()
            where T : TopLevelViewModelBase
        {
            var targetViewModel = _topLevelViewModelFactory.CreateViewModel<T>();
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(targetViewModel));
        }

        public void NavigateTo(TopLevelViewModelBase target)
        {
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(target));
        }
    }
}