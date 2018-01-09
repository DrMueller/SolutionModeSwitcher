using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Construction;
using Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services;

namespace Mmu.Sms.DomainServices.Shell.Areas.Infrastructure.MicrosoftBuild
{
    public class SolutionFileService : ISolutionFileService
    {
        public IReadOnlyCollection<DomainServices.Infrastructure.MicrosoftBuild.Models.ProjectInSolution> ParseMicrosoftBuildProjects(string solutionFilePath)
        {
            var solutionFile = SolutionFile.Parse(solutionFilePath);
            var result = new List<DomainServices.Infrastructure.MicrosoftBuild.Models.ProjectInSolution>();
            var projectReferences = solutionFile.ProjectsInOrder.Where(f => f.ProjectType == SolutionProjectType.KnownToBeMSBuildFormat);

            foreach (var project in projectReferences)
            {
                var proj = new DomainServices.Infrastructure.MicrosoftBuild.Models.ProjectInSolution(
                    project.AbsolutePath,
                    project.ProjectGuid,
                    project.ProjectName);

                result.Add(proj);
            }

            return result;
        }
    }
}