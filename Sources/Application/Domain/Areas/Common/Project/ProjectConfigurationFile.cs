using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectConfigurationFile
    {
        public ProjectConfigurationFile(
            string filePath,
            IReadOnlyCollection<ImportEntry> importEntries)
        {
            Guard.StringNotNullOrEmpty(() => filePath);

            FilePath = filePath;
            ImportEntries = importEntries;
        }

        public string FilePath { get; }
        public IReadOnlyCollection<ImportEntry> ImportEntries { get; }
    }
}