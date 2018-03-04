using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectReferences.Implementation
{
    public class ProjectReferenceToXmlAdapter : IProjectReferenceToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public ProjectReferenceToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var builder = _xmlElementBuilderFactory.CreateTopLevelElement("ItemGroup");

            foreach(var projectRef in projectConfigFile.ProjectReferences)
            {
                builder.StartBuildingChildElement("ProjectReference")
                    .WithAttribute("Include")
                        .WithAttributeValue(projectRef.RelativeProjectFileIncludePath)
                        .BuildAttribute()
                    .StartBuildingChildElement("Project")
                        .WithElementValue(projectRef.ProjectGuid)
                        .BuildElement()
                    .StartBuildingChildElement("Name")
                        .WithElementValue(projectRef.AssemblyName)
                        .BuildElement()
                    .BuildElement();
            }

            var result = builder.FinishBuilding();
            return result;
        }
    }
}
