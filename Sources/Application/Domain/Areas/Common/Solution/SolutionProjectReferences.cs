using System.Collections.Generic;
using System.Linq;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectReferences
    {
        private List<SolutionProjectReference> _entries;

        public SolutionProjectReferences(List<SolutionProjectReference> entries)
        {
            _entries = entries;
        }

        public IReadOnlyCollection<SolutionProjectReference> Entries => _entries;

        public void AddReferenceSorted(SolutionProjectReference projectReference)
        {
            _entries.Add(projectReference);
            _entries = _entries.OrderBy(f => f.AssemblyName).ToList();
        }

        public void RemoveReferences(IReadOnlyCollection<string> assemblyNames)
        {
            var entriesToRemove = _entries.Where(f => assemblyNames.Contains(f.AssemblyName)).ToList();
            _entries = _entries.Except(entriesToRemove).ToList();
        }

        public IReadOnlyCollection<SolutionProjectReference> RemoveReferencesExcept(IReadOnlyCollection<string> exceptThisAssemblyNames)
        {
            var entriesToRemove = _entries.Where(f => !exceptThisAssemblyNames.Contains(f.AssemblyName)).ToList();
            _entries = _entries.Except(entriesToRemove).ToList();

            return entriesToRemove;
        }
    }
}