using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common._LegacyProject
{
    public class ProjectAssemblyReference
    {
        public ProjectAssemblyReference(IncludeDefinition includeDefinition, string hintPath, bool? isPrivate, bool? specificVersion)
        {
            Guard.ObjectNotNull(() => includeDefinition);

            IncludeDefinition = includeDefinition;
            HintPath = hintPath;
            IsPrivate = isPrivate;
            SpecificVersion = specificVersion;
        }

        public string HintPath { get; }
        public IncludeDefinition IncludeDefinition { get; }
        public bool? IsPrivate { get; }
        public bool? SpecificVersion { get; }
    }
}