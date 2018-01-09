using Microsoft.Build.Evaluation;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services;

namespace Mmu.Sms.DomainServices.Shell.Areas.Infrastructure.MicrosoftBuild
{
    public class ProjectBuildService : IProjectBuildService
    {
        public ProjectBuildService()
        {
            AssureDependencies();
        }

        public async System.Threading.Tasks.Task BuildProjectAsync(string filePath)
        {
            var buildTask = System.Threading.Tasks.Task.Run(() => BuildProject(filePath));
            await buildTask;
        }

        private static void AssureDependencies()
        {
            // There is a dependency problem in the packages, so we create one manually to Microsoft.Build.Utilities.Core
#pragma warning disable 219
            var tra = ExecutableType.Managed32Bit;
            var tra2 = new Exec();
#pragma warning restore 219
        }

        private static void BuildProject(string projectFilePath)
        {
            var buildCollection = new ProjectCollection();
            var project = buildCollection.LoadProject(projectFilePath);
            project.Build();
        }
    }
}