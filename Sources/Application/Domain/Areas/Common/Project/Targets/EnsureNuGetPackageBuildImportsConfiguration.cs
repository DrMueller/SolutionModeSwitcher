using System.Collections.Generic;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class EnsureNuGetPackageBuildImportsConfiguration
    {
        public EnsureNuGetPackageBuildImportsConfiguration(string beforeTargets, string errorText, IReadOnlyCollection<TargetError> targetErrors)
        {
            BeforeTargets = beforeTargets;
            ErrorText = errorText;
            TargetErrors = targetErrors;
        }

        public string BeforeTargets { get; }
        public string ErrorText { get; }
        public IReadOnlyCollection<TargetError> TargetErrors { get; }
    }
}