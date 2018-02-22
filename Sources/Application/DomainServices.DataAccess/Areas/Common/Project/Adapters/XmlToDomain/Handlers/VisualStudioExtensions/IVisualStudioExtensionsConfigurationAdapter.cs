using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectExtensions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioExtensions
{
    public interface IVisualStudioExtensionsConfigurationAdapter
    {
        Maybe<VisualStudioExtensionsConfiguration> Adapt(XDocument document);
    }
}