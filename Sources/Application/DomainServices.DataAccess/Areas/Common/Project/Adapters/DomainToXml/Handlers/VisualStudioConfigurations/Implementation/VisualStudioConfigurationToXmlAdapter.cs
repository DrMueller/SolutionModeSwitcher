using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.VisualStudioConfigurations.Implementation
{
    public class VisualStudioConfigurationToXmlAdapter : IVisualStudioConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public VisualStudioConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var builder = _xmlElementBuilderFactory.CreateTopLevelElement("PropertyGroup");

            projectConfigFile.VisualStudioConfiguration.VisualStudioVersion.Evaluate(
                version =>
                {
                    builder.StartBuildingChildElement("VisualStudioVersion")
                        .WithConditionAttribute(version.Condition)
                        .WithElementValue(version.Version)
                        .BuildElement();
                });

            projectConfigFile.VisualStudioConfiguration.VisualStudioToolsPath.Evaluate(
                toolsPath =>
                {
                    builder.StartBuildingChildElement("VSToolsPath")
                        .WithConditionAttribute(toolsPath.Condition)
                        .WithElementValue(toolsPath.ToolsPath)
                        .BuildElement();
                });

            var result = builder.FinishBuilding();
            return result;
        }
    }
}