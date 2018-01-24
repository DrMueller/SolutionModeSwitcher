using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public class SolutionPropertiesSectionToStringAdapter : SectionToStringAdapterBase, ISolutionPropertiesSectionToStringAdapter
    {
        public void Adapt(SolutionProperties solutionProperties, IExtendedStringBuilder sb)
        {
            StartBuilding(sb, "SolutionProperties", true);

            var hideSolutionNodeValue = $"HideSolutionNode = {solutionProperties.HideSolutionNode.ToString().ToUpperInvariant()}";
            sb.AppendLine(hideSolutionNodeValue, 2);

            EndBuilding(sb);
        }
    }
}