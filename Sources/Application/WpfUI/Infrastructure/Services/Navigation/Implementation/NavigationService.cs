using Mmu.Sms.WpfUI.Infrastructure.Extensions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.Factories;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly INavigationConfigurationService _navigationHandlerConfiguration;
        private readonly IViewModelFactory _viewModelFactory;

        public NavigationService(INavigationConfigurationService navigationHandlerConfiguration, IViewModelFactory viewModelFactory)
        {
            _navigationHandlerConfiguration = navigationHandlerConfiguration;
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<T>()
            where T : ViewModelBase
        {
            var targetViewModel = _viewModelFactory.CreateViewModel<T>();
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(targetViewModel));
        }

        public void NavigateTo(ViewModelBase target)
        {
            _navigationHandlerConfiguration.NavigationRequestedCallbacks.ForEach(f => f.Invoke(target));
        }
    }
}