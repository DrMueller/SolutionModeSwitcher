using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectItem
    {
        public SolutionProjectItem(string leftItemPath, string rightItemPath)
        {
            // .eslintrc.json = .eslintrc.json
            Guard.StringNotNullOrEmpty(() => leftItemPath);
            Guard.StringNotNullOrEmpty(() => rightItemPath);

            LeftItemPath = leftItemPath;
            RightItemPath = rightItemPath;
        }

        public string LeftItemPath { get; }
        public string RightItemPath { get; }
    }
}