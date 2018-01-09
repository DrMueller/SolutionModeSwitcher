using System;
using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Configuration;

namespace Mmu.Sms.DomainServices.Areas.Configuration.Factories.Implementation
{
    public class SolutionModeConfigurationFactory : ISolutionModeConfigurationFactory
    {
        public SolutionModeConfiguration Create(
            string id,
            string configurationName,
            string solutionFilePath,
            IReadOnlyCollection<ProjectReferenceConfiguration> projectReferenceConfigurations)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }

            var result = new SolutionModeConfiguration(id, configurationName, solutionFilePath, projectReferenceConfigurations);
            return result;
        }
    }
}