using System.Collections.Generic;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Services
{
    public interface ISolutionModeConfigurationService
    {
        void DeleteConfiguration(string configurationId);

        void Initialize(string configurationDirectory);

        SolutionModeConfigurationDto Load(string configurationId);

        IReadOnlyCollection<SolutionModeConfigurationDto> LoadAll();

        SolutionModeConfigurationDto SaveConfiguration(SolutionModeConfigurationDto configurationDto);
    }
}