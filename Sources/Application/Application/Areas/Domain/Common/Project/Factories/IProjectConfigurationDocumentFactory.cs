using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.Application.Areas.Domain.Common.Project.Factories
{
    public interface IProjectConfigurationDocumentFactory
    {
        IXDocumentProxy CreateDocument(ProjectConfigurationFile projectConfigFile);
    }
}