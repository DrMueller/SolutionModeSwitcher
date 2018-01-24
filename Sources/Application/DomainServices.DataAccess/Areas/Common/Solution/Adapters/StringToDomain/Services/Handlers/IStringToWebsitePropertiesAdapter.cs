using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers
{
    public interface IStringToWebsitePropertiesAdapter
    {
        Maybe<WebsiteProperties> Adapt(string projectGuid, List<string> solutionDataLines);
    }
}