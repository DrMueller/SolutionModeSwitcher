using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Dtos;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services
{
    public interface IProjectSearchService
    {
        Task<IReadOnlyCollection<BuildableProjectDto>> SearchProjectsAsync(SolutionModeConfigurationDto configurationDto);
    }
}