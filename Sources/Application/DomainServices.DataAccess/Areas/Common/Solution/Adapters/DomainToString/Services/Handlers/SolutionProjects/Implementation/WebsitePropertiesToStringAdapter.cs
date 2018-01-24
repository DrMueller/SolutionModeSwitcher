using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects.Implementation
{
    public class WebsitePropertiesToStringAdapter : IWebsitePropertiesToStringAdapter
    {
        public void Adapt(Maybe<WebsiteProperties> websiteProperties, IExtendedStringBuilder sb)
        {
            websiteProperties.Evaluate(
                wb =>
                {
                    Adapt(wb, sb);
                });
        }

        private static void Adapt(WebsiteProperties websiteProperties, IExtendedStringBuilder sb)
        {
            sb.AppendLine("ProjectSection(WebsiteProperties) = preProject", 1);
            sb.AppendLine(websiteProperties.Data);
            sb.AppendLine("EndProjectSection", 1);
        }
    }
}