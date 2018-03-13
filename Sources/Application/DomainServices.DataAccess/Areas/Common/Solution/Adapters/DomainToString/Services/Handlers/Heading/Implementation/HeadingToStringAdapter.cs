using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Heading.Implementation
{
    public class HeadingToStringAdapter : IHeadingToStringAdapter
    {
        public void Adapt(SolutionHeadingElement headingElement, IExtendedStringBuilder sb)
        {
            sb.AppendLine(headingElement.FormatDescription);
            sb.AppendLine(headingElement.VisualStudioDescription);
            sb.AppendLine(headingElement.VisualStudioVersion);
            sb.AppendLine(headingElement.MinimalVisualStudioVersion);
        }
    }
}