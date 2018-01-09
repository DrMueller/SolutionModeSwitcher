using System;
using System.Collections.Generic;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation
{
    public interface INavigationConfigurationService
    {
        IReadOnlyCollection<Action<ViewModelBase>> NavigationRequestedCallbacks { get; }

        void AddNavigationRequestedCallback(Action<ViewModelBase> navigationRequestedCallback);
    }
}