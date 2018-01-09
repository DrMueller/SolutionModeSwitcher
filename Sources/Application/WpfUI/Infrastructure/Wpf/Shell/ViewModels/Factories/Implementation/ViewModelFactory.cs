using System;
using Mmu.Sms.Common.Ioc;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.Factories.Implementation
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IProvisioningService _provisioningService;

        public ViewModelFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public ViewModelBase CreateViewModel<T>()
            where T : ViewModelBase
        {
            return CreateViewModel(typeof(T));
        }

        public ViewModelBase CreateViewModel(Type viewModelType)
        {
            var viewModelBaseType = typeof(ViewModelBase);

            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from ViewModelBase.");
            }

            var viewModel = (ViewModelBase)_provisioningService.GetService(viewModelType);

            return viewModel;
        }
    }
}