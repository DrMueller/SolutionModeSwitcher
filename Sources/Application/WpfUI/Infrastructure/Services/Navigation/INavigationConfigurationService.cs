using System;
using System.Collections.Generic;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Navigation
{
    public interface INavigationConfigurationService
    {
        IReadOnlyCollection<Action<TopLevelViewModelBase>> NavigationRequestedCallbacks { get; }

        void AddNavigationRequestedCallback(Action<TopLevelViewModelBase> navigationRequestedCallback);
    }
}