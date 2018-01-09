using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ProjectBuilding;

namespace Mmu.Sms.DomainServices.Areas.ProjectBuilding.Services.Implementation
{
    public class ProjectSearchService : IProjectSearchService
    {
        private readonly IDirectoryProxy _directoryProxy;
        private readonly IPathProxy _pathProxy;

        public ProjectSearchService(IDirectoryProxy directoryProxy, IPathProxy pathProxy)
        {
            _directoryProxy = directoryProxy;
            _pathProxy = pathProxy;
        }

        public Task<IReadOnlyCollection<BuildableProject>> SearchProjectsAsync(SolutionModeConfiguration configuration)
        {
            var result = Task.Run(() => SearchProjects(configuration));

            return result;
        }

        private IReadOnlyCollection<BuildableProject> SearchProjects(SolutionModeConfiguration configuration)
        {
            var directory = _pathProxy.GetDirectoryName(configuration.SolutionFilePath);
            var csprojFiles = _directoryProxy.GetFiles(directory, "*.csproj");
            var projects = (IReadOnlyCollection<BuildableProject>)csprojFiles.Select(f => new BuildableProject(f)).ToList();
            return projects;
        }
    }
}