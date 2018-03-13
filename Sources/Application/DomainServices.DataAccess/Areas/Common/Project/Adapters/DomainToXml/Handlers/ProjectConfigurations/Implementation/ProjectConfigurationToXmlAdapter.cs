using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectConfigurations.Implementation
{
    public class ProjectConfigurationToXmlAdapter : IProjectConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public ProjectConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = _xmlElementBuilderFactory.CreateTopLevelElement("Project")
                .WithAttribute("ToolsVersion")
                .WithAttributeValue(projectConfigFile.ProjectConfiguration.ToolsVersion)
                .BuildAttribute()
                .WithAttribute("DefaultTargets")
                .WithAttributeValue(projectConfigFile.ProjectConfiguration.DefaultTargets)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildAttribute()
                .FinishBuilding();

            return result;

            //// https://stackoverflow.com/questions/23698767/the-prefix-cannot-be-redefined-from-to-url-within-the-same-start-element-t
            //XNamespace ns = projectConfigFile.ProjectConfiguration.XmlNamespace;

            //var result = _xmlElementBuilderFactory.CreateTopLevelElement(ns + "Project")
            //    .WithAttribute("ToolsVersion")
            //    .WithAttributeValue(projectConfigFile.ProjectConfiguration.ToolsVersion)
            //    .BuildAttribute()
            //    .WithAttribute("DefaultTargets")
            //    .WithAttributeValue(projectConfigFile.ProjectConfiguration.DefaultTargets)
            //    .BuildAttribute()
            //    .WithAttribute("xmlns")
            //    .WithAttributeValue(projectConfigFile.ProjectConfiguration.XmlNamespace)
            //    .BuildAttribute()
            //    .FinishBuilding();

            //return result;
        }
    }
}