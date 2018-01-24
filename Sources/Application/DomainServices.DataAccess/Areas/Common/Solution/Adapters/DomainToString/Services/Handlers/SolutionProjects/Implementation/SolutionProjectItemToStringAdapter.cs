using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects.Implementation
{
    public class SolutionProjectItemToStringAdapter : ISolutionProjectItemToStringAdapter
    {
        public void Adapt(IEnumerable<SolutionProjectItem> solutionProjectItems, IExtendedStringBuilder sb)
        {
            if (!solutionProjectItems.Any())
            {
                return;
            }

            sb.AppendLine("ProjectSection(SolutionItems) = preProject", 1);

            foreach (var item in solutionProjectItems)
            {
                sb.AppendLine($"{item.LeftItemPath} = {item.RightItemPath}", 2);
            }

            sb.AppendLine("EndProjectSection", 1);
        }
    }
}