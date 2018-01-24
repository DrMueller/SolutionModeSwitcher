using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class GlobalExtensibilities
    {
        public GlobalExtensibilities(string solutionGuid)
        {
            Guard.StringNotNullOrEmpty(() => solutionGuid);
            SolutionGuid = solutionGuid;
        }

        public string SolutionGuid { get; }
    }
}