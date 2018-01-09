using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Configuration
{
    public class SolutionModeConfiguration
    {
        public SolutionModeConfiguration(
            string id,
            string configurationName,
            string solutionFilePath,
            IReadOnlyCollection<ProjectReferenceConfiguration> projectReferenceConfigurations)
        {
            Guard.StringNotNullOrEmpty(() => solutionFilePath);
            Guard.ObjectNotNull(() => projectReferenceConfigurations);

            Id = id;
            ConfigurationName = configurationName;
            SolutionFilePath = solutionFilePath;
            ProjectReferenceConfigurations = projectReferenceConfigurations;
        }

        public IReadOnlyCollection<ProjectReferenceConfiguration> ProjectReferenceConfigurations { get; }
        public string Id { get; }
        public string ConfigurationName { get; }
        public string SolutionFilePath { get; }
    }
}