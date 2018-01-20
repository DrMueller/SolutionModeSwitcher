using System.Collections.Generic;
using Microsoft.Build.Construction;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionProjectConfigurationFactory : ISolutionProjectConfigurationFactory
    {
        public IReadOnlyCollection<SolutionProjectConfiguration> Create(ProjectInSolution project)
        {
            var result = new List<SolutionProjectConfiguration>();

            foreach (var projConfig in project.ProjectConfigurations)
            {
                var solutionProjectConfig = new SolutionProjectConfiguration(
                    projConfig.Key,
                    projConfig.Value.PlatformName,
                    projConfig.Value.IncludeInBuild,
                    projConfig.Value.FullName,
                    projConfig.Value.ConfigurationName);

                result.Add(solutionProjectConfig);
            }

            return result;
        }
    }
}