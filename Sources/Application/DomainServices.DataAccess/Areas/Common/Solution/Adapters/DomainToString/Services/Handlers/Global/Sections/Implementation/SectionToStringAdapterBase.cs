using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public abstract class SectionToStringAdapterBase
    {
        protected void EndBuilding(IExtendedStringBuilder sb)
        {
            sb.AppendLine("EndGlobalSection", 1);
        }

        protected void StartBuilding(IExtendedStringBuilder sb, string sectionName, bool isPreSolution)
        {
            var preSolutionValue = isPreSolution ? "preSolution" : "postSolution";
            sb.AppendLine($"GlobalSection({sectionName}) = {preSolutionValue}", 1);
        }
    }
}