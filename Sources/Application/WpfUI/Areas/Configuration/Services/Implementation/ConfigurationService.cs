using System.Collections.Generic;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.Confguration.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.AppSettings;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ISolutionModeConfigurationService _configurationAppService;
        private readonly IInformationPublishingService _informationPublishingService;

        public ConfigurationService(
            IAppSettingsService appSettingsService,
            ISolutionModeConfigurationService configurationAppService,
            IInformationPublishingService informationPublishingService)
        {
            _configurationAppService = configurationAppService;
            _informationPublishingService = informationPublishingService;

            var configurationDirectory = appSettingsService.GetConfigurationDirectory();
            configurationAppService.Initialize(configurationDirectory);
        }

        public void DeleteConfiguration(string configurationId)
        {
            _informationPublishingService.Publish(InformationType.Important, "Deleting...");
            _configurationAppService.DeleteConfiguration(configurationId);
            _informationPublishingService.Publish(InformationType.Success, "Configuration deleted!");
        }

        public IReadOnlyCollection<SolutionModeConfigurationDto> LoadAllConfigurations()
        {
            var result = _configurationAppService.LoadAll();
            return result;
        }

        public SolutionModeConfigurationDto SaveConfiguration(SolutionModeConfigurationDto configuration)
        {
            _informationPublishingService.Publish(InformationType.Important, $"Saving {configuration.ConfigurationName}...");
            var result = _configurationAppService.SaveConfiguration(configuration);
            _informationPublishingService.Publish(InformationType.Success, $"{configuration.ConfigurationName} saved!");
            return result;
        }
    }
}