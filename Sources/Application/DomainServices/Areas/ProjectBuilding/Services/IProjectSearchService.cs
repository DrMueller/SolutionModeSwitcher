using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ProjectBuilding;

namespace Mmu.Sms.DomainServices.Areas.ProjectBuilding.Services
{
    public interface IProjectSearchService
    {
        Task<IReadOnlyCollection<BuildableProject>> SearchProjectsAsync(SolutionModeConfiguration configuration);
    }
}