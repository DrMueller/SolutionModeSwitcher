using System.Threading.Tasks;

namespace Mmu.Sms.DomainServices.Areas.ProjectBuilding.Services.Implementation
{
    public class ProjectBuildService : IProjectBuildService
    {
        private readonly Infrastructure.MicrosoftBuild.Services.IProjectBuildService _projectBuildService;

        public ProjectBuildService(Infrastructure.MicrosoftBuild.Services.IProjectBuildService projectBuildService)
        {
            _projectBuildService = projectBuildService;
        }

        public async Task BuildProjectAsync(string filePath)
        {
            await _projectBuildService.BuildProjectAsync(filePath);
        }
    }
}