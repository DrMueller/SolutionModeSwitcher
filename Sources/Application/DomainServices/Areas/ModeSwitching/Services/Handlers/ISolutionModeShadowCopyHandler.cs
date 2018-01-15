using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Handlers
{
    public interface ISolutionModeShadowCopyHandler
    {
        void Initialize();

        void AddCopy(SolutionConfigurationFile solutionConfigFile);

        void AddCopy(ProjectConfigurationFile projectConfigFile);

        void Commit();
    }
}