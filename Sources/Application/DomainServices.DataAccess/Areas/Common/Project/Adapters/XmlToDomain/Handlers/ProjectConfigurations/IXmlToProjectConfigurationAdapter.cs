using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectConfigurations;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectConfigurations
{
    public interface IXmlToProjectConfigurationAdapter
    {
        ProjectConfiguration Adapt(XDocument document);
    }
}