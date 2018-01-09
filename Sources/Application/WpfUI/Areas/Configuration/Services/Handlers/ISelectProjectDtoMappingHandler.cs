using System.Collections.Generic;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Dtos;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services.Handlers
{
    public interface ISelectProjectDtoMappingHandler
    {
        IReadOnlyCollection<SelectProjectDto> Map(IReadOnlyCollection<ProjectReferenceConfigurationDto> dtos, SolutionModeConfigurationDto configuration);
    }
}