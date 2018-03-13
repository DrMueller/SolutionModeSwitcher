using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public class NestedProjectsSectionToStringAdapter : SectionToStringAdapterBase, INestedProjectsSectionToStringAdapter
    {
        public void Adapt(IEnumerable<SolutionProject> solutionProjects, IExtendedStringBuilder sb)
        {
            StartBuilding(sb, "NestedProjects", true);
            var solutionProjectsWithParents = solutionProjects.Where(f => !string.IsNullOrEmpty(f.ParentProjectGuid));
            foreach (var solutionProjectWithParent in solutionProjectsWithParents)
            {
                var nestedEntry = $"{solutionProjectWithParent.ProjectGuid} = {solutionProjectWithParent.ParentProjectGuid}";
                sb.AppendLine(nestedEntry, 2);
            }

            EndBuilding(sb);
        }
    }
}