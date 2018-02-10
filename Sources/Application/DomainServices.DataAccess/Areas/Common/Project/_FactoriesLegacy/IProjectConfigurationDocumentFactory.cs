using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy
{
    public interface IProjectConfigurationDocumentFactory
    {
        IXDocumentProxy CreateDocument(ProjectConfigurationFile projectConfigurationFile);
    }
}