using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Project.ImportEntries
{
    public class ImportEntry
    {
        public ImportEntry(string condition, string relativeProjectPath)
        {
            Guard.StringNotNullOrEmpty(() => relativeProjectPath);

            Condition = condition;
            RelativeProjectPath = relativeProjectPath;
        }

        public string Condition { get; }
        public string RelativeProjectPath { get; }
    }
}