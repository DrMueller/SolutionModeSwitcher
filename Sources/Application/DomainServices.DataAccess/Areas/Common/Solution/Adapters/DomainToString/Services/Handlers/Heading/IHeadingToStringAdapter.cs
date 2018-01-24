using System.Text;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Heading
{
    public interface IHeadingToStringAdapter
    {
        void Adapt(SolutionHeadingElement headingElement, IExtendedStringBuilder sb);
    }
}