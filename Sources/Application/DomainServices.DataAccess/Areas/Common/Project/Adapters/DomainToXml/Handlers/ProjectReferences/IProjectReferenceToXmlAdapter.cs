using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectReferences
{
    public interface IProjectReferenceToXmlAdapter
    {
        XElement Adapt(ProjectConfigurationFile projectConfigFile);
    }
}