using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.VisualStudio;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioConfigurations
{
    public interface IVisualStudioConfigurationAdapter
    {
        VisualStudioConfiguration Adapt(XDocument document);
    }
}