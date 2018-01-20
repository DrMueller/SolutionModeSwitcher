using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionConfigurationFile
    {
        public SolutionConfigurationFile(string filePath, SolutionProjectReferences solutionProjectReferences)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            Guard.ObjectNotNull(() => solutionProjectReferences);

            FilePath = filePath;
            SolutionProjectReferences = solutionProjectReferences;
        }

        public string FilePath { get; }
        
        public SolutionProjectReferences SolutionProjectReferences { get; }

        public IReadOnlyCollection<SolutionProjectReference> RemoveProjectReferencesExcept(IReadOnlyCollection<string> assemblyNames)
        {
            var removedReferences = SolutionProjectReferences.RemoveReferencesExcept(assemblyNames);
            return removedReferences;
        }
    }
}