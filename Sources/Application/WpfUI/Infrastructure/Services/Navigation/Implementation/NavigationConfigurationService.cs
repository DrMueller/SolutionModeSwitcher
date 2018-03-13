using System;
using System.Collections.Generic;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation.Implementation
{
    public class NavigationConfigurationService : INavigationConfigurationService
    {
        private readonly List<Action<TopLevelViewModelBase>> _navigationRequestedCallbacks = new List<Action<TopLevelViewModelBase>>();
        public IReadOnlyCollection<Action<TopLevelViewModelBase>> NavigationRequestedCallbacks => _navigationRequestedCallbacks;

        public void AddNavigationRequestedCallback(Action<TopLevelViewModelBase> navigationRequestedCallback)
        {
            _navigationRequestedCallbacks.Add(navigationRequestedCallback);
        }
    }
}