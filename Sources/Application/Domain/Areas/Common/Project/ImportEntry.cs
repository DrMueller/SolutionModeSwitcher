using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ImportEntry
    {
        public ImportEntry(string relativePath, string condition)
        {
            Guard.StringNotNullOrEmpty(() => relativePath);

            RelativePath = relativePath;
            Condition = condition;
        }

        public string Condition { get; }
        public string RelativePath { get; }
    }
}