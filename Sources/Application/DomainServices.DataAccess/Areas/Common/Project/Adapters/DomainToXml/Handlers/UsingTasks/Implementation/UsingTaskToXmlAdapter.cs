using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.UsingTasks.Implementation
{
    public class UsingTaskToXmlAdapter : IUsingTaskToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public UsingTaskToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.UsingTasks.Select(
                    usingTask => _xmlElementBuilderFactory.CreateTopLevelElement("UsingTask")
                        .WithAttribute("TaskName")
                        .WithAttributeValue(usingTask.TaskName)
                        .BuildAttribute()
                        .WithAttribute("AssemblyFile")
                        .WithAttributeValue(usingTask.AssemblyFile)
                        .BuildAttribute()
                        .FinishBuilding())
                .ToList();

            return result;
        }
    }
}