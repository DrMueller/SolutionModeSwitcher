using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectProperties
{
    public interface IProjectPropertiesConfigurationToXmlAdapter
    {
        XElement Adapt(ProjectConfigurationFile projectConfigFile);
    }
}