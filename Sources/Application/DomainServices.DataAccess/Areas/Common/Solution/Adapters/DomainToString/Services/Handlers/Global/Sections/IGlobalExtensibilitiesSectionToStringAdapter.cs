using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections
{
    public interface IGlobalExtensibilitiesSectionToStringAdapter
    {
        void Adapt(GlobalExtensibilities globalExtensibilities, IExtendedStringBuilder sb);
    }
}