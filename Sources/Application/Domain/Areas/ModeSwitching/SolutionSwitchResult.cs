using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.Domain.Areas.ModeSwitching
{
    public class SolutionSwitchResult
    {
        public SolutionSwitchResult(
            SolutionConfigurationFile switchedSolutionConfigFile,
            IReadOnlyCollection<ProjectConfigurationFile> switchedProjectConfigFiles)
        {
            Guard.ObjectNotNull(() => switchedSolutionConfigFile);
            Guard.ObjectNotNull(() => switchedProjectConfigFiles);

            SwitchedSolutionConfigFile = switchedSolutionConfigFile;
            SwitchedProjectConfigFiles = switchedProjectConfigFiles;
        }

        public IReadOnlyCollection<ProjectConfigurationFile> SwitchedProjectConfigFiles { get; }
        public SolutionConfigurationFile SwitchedSolutionConfigFile { get; }
    }
}