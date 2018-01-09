using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Configuration;

namespace Mmu.Sms.DomainServices.Areas.Configuration.Factories
{
    public interface ISolutionModeConfigurationFactory
    {
        SolutionModeConfiguration Create(
            string id,
            string configurationName,
            string solutionFilePath,
            IReadOnlyCollection<ProjectReferenceConfiguration> projectReferenceConfigurations);
    }
}