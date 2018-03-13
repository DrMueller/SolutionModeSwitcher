using System;
using Mmu.Sms.Common.Ioc;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel.Factories.Implementation
{
    public class TopLevelViewModelFactory : ITopLevelViewModelFactory
    {
        private readonly IProvisioningService _provisioningService;

        public TopLevelViewModelFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public TopLevelViewModelBase CreateViewModel<T>()
            where T : ViewModelBase
        {
            return CreateViewModel(typeof(T));
        }

        public TopLevelViewModelBase CreateViewModel(Type viewModelType)
        {
            var viewModelBaseType = typeof(TopLevelViewModelBase);

            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from TopLevelViewModeBase.");
            }

            var topLevelViewModel = (TopLevelViewModelBase)_provisioningService.GetService(viewModelType);
            return topLevelViewModel;
        }
    }
}