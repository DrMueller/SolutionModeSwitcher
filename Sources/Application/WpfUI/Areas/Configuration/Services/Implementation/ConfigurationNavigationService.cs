using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.WpfUI.Areas.Configuration.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services.Implementation
{
    public class ConfigurationNavigationService : IConfigurationNavigationService
    {
        private readonly INavigationService _navigationHandler;
        private readonly IProvisioningService _provisioningService;

        public ConfigurationNavigationService(
            INavigationService navigationHandler,
            IProvisioningService provisioningService)
        {
            _navigationHandler = navigationHandler;
            _provisioningService = provisioningService;
        }

        public void NavigateToDetails(Maybe<SolutionModeConfigurationDto> configurationMaybe)
        {
            var viewModel = _provisioningService.GetService<ConfigurationDetailsViewModel>();
            viewModel.Initialize(configurationMaybe);
            _navigationHandler.NavigateTo(viewModel);
        }
    }
}