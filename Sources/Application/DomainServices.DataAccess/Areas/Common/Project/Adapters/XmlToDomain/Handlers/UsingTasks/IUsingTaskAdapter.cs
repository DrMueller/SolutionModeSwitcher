using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Tasks;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.UsingTasks
{
    public interface IUsingTaskAdapter
    {
        IReadOnlyCollection<UsingTask> Adapt(XDocument document);
    }
}