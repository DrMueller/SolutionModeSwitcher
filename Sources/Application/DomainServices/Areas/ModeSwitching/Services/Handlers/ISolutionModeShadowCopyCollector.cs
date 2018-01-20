using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Handlers
{
    public interface ISolutionModeShadowCopyCollector
    {
        void AddProjectConfigurationFileCopy(ProjectConfigurationFile projectConfigFile);

        void Initialize(string configurationId);

        void Save();

        void SetSolutionConfigurationFileCopy(SolutionConfigurationFile solutionConfigFile);
    }
}