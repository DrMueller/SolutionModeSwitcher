using System.Collections.Generic;
using Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Models;

namespace Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services
{
    public interface ISolutionFileService
    {
        IReadOnlyCollection<ProjectInSolution> ParseMicrosoftBuildProjects(string solutionFilePath);
    }
}