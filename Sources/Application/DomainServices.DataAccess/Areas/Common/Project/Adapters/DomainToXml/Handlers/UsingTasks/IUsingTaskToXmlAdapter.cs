using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.UsingTasks
{
    public interface IUsingTaskToXmlAdapter
    {
        IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile);
    }
}