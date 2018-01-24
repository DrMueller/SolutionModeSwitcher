using System.Collections.Generic;
using Microsoft.Build.Construction;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToSolutionConfigurationAdapter : IStringToSolutionConfigurationAdapter
    {
        public ICollection<SolutionConfiguration> Adapt(string filePath)
        {
            var result = new List<SolutionConfiguration>();
            var solutionFile = SolutionFile.Parse(filePath);

            foreach (var nativeConfig in solutionFile.SolutionConfigurations)
            {
                var solutionConfig = new SolutionConfiguration(
                    nativeConfig.ConfigurationName,
                    nativeConfig.FullName,
                    nativeConfig.PlatformName);

                result.Add(solutionConfig);
            }

            return result;
        }
    }
}