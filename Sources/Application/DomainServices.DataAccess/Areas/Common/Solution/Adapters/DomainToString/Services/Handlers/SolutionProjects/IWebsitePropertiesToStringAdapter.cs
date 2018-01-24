using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects
{
    public interface IWebsitePropertiesToStringAdapter
    {
        void Adapt(Maybe<WebsiteProperties> websiteProperties, IExtendedStringBuilder sb);
    }
}