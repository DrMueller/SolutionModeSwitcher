using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public class GlobalExtensibilitiesSectionToStringAdapter : SectionToStringAdapterBase, IGlobalExtensibilitiesSectionToStringAdapter
    {
        public void Adapt(GlobalExtensibilities globalExtensibilities, IExtendedStringBuilder sb)
        {
            StartBuilding(sb, "ExtensibilityGlobals", false);
            sb.AppendLine($"SolutionGuid = {globalExtensibilities.SolutionGuid}", 2);
            EndBuilding(sb);
        }
    }
}