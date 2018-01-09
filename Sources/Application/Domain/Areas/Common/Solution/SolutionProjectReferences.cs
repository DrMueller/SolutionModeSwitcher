using System.Collections.Generic;
using System.Linq;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectReferences
    {
        public SolutionProjectReferences(IReadOnlyCollection<SolutionProjectReference> entries)
        {
            Entries = entries;
        }

        public IReadOnlyCollection<SolutionProjectReference> Entries { get; private set; }

        public bool CheckIfContaintsReference(string assemblyName)
        {
            return Entries.Any(f => f.AssemblyName == assemblyName);
        }

        public IReadOnlyCollection<SolutionProjectReference> RemoveReferencesWithStartingNamespace(IReadOnlyCollection<string> exceptThisAssemblyNames)
        {
            var entriesToRemove = Entries.Where(f => !exceptThisAssemblyNames.Contains(f.AssemblyName)).ToList();
            Entries = Entries.Except(entriesToRemove).ToList();

            return entriesToRemove;
        }
    }
}