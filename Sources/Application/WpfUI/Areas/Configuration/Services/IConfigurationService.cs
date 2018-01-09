using System.Collections.Generic;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services
{
    public interface IConfigurationService
    {
        void DeleteConfiguration(string configurationId);

        SolutionModeConfigurationDto SaveConfiguration(SolutionModeConfigurationDto configuration);

        IReadOnlyCollection<SolutionModeConfigurationDto> LoadAllConfigurations();
    }
}