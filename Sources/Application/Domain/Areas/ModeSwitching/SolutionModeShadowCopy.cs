using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.Domain.Areas.ModeSwitching
{
    public class SolutionModeShadowCopy
    {
        public SolutionModeShadowCopy(
            string configurationId,
            SolutionConfigurationFile solutionConfigFile,
            IReadOnlyCollection<ProjectConfigurationFile> projectConfigFiles)
        {
            Guard.StringNotNullOrEmpty(() => configurationId);
            Guard.ObjectNotNull(() => solutionConfigFile);
            Guard.ObjectNotNull(() => projectConfigFiles);

            ConfigurationId = configurationId;
            SolutionConfigFile = solutionConfigFile;
            ProjectConfigFiles = projectConfigFiles;
        }

        public string ConfigurationId { get; }
        public IReadOnlyCollection<ProjectConfigurationFile> ProjectConfigFiles { get; }
        public SolutionConfigurationFile SolutionConfigFile { get; }
    }
}