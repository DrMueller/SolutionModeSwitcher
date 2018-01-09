using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.ProjectBuilding
{
    public class BuildableProject
    {
        public BuildableProject(string filePath)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}