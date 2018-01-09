using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Domain.Areas.Configuration;

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

        public bool CheckIfContainsReference(string assemblyName)
        {
            return SolutionProjectReferences.CheckIfContaintsReference(assemblyName);
        }

        public IReadOnlyCollection<SolutionProjectReference> RemoveReferences(SolutionModeConfiguration modeConfiguration)
        {
            var projectReferenceAssemblyNames = modeConfiguration.ProjectReferenceConfigurations.Select(f => f.AssemblyName).ToList();

            var removedReferences = SolutionProjectReferences.RemoveReferencesWithStartingNamespace(projectReferenceAssemblyNames);
            return removedReferences;
        }
    }
}