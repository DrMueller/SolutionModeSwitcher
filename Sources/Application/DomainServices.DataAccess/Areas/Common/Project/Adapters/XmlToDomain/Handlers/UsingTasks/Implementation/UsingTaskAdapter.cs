using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Tasks;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.UsingTasks.Implementation
{
    public class UsingTaskAdapter : IUsingTaskAdapter
    {
        public IReadOnlyCollection<UsingTask> Adapt(XDocument document)
        {
            var taskElements = document.Descendants().Where(f => f.Name.LocalName == "UsingTask");
            var result = taskElements.Select(AdaptFromElement).ToList();

            return result;
        }

        private UsingTask AdaptFromElement(XElement element)
        {
            var taskName = element.Attributes().First(f => f.Name.LocalName == "TaskName").Value;
            var assemblyFile = element.Attributes().First(f => f.Name.LocalName == "AssemblyFile").Value;

            var result = new UsingTask(taskName, assemblyFile);
            return result;
        }
    }
}