using System;
using System.Collections.Generic;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation.Implementation
{
    public class NavigationConfigurationService : INavigationConfigurationService
    {
        private readonly List<Action<ViewModelBase>> _navigationRequestedCallbacks = new List<Action<ViewModelBase>>();
        public IReadOnlyCollection<Action<ViewModelBase>> NavigationRequestedCallbacks => _navigationRequestedCallbacks;

        public void AddNavigationRequestedCallback(Action<ViewModelBase> navigationRequestedCallback)
        {
            _navigationRequestedCallbacks.Add(navigationRequestedCallback);
        }
    }
}