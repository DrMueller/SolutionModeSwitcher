using System.Threading.Tasks;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services.Implementation
{
    public class ProjectBuildService : IProjectBuildService
    {
        private readonly DomainServices.Areas.ProjectBuilding.Services.IProjectBuildService _projectBuildService;

        public ProjectBuildService(DomainServices.Areas.ProjectBuilding.Services.IProjectBuildService projectBuildService)
        {
            _projectBuildService = projectBuildService;
        }

        public async Task BuildProjectAsync(string filePath)
        {
            await _projectBuildService.BuildProjectAsync(filePath);
        }
    }
}