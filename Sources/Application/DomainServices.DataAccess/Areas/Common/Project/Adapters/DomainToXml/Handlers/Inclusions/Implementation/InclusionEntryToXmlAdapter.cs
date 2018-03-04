using System;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Inclusions.Implementation
{
    public class InclusionEntryToXmlAdapter : IInclusionEntryToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public InclusionEntryToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile, BuildAction buildAction)
        {
            var builder = _xmlElementBuilderFactory.CreateTopLevelElement("ItemGroup");

            var includes = projectConfigFile.InclusionEntries.Where(f => f.BuildAction == buildAction);
            var elementName = MapElementName(buildAction);

            foreach (var include in includes)
            {
                builder.StartBuildingChildElement(elementName)
                    .WithAttribute("Include")
                    .WithAttributeValue(include.IncludePath)
                    .BuildAttribute()
                    .StartBuildingChildElement("AugoGen")
                    .WithElementValue(include.AutoGen)
                    .WithCondition(XmlBuildingCondition.NotNull)
                    .BuildElement()
                    .StartBuildingChildElement("DesignTime")
                    .WithElementValue(include.DesignTime)
                    .WithCondition(XmlBuildingCondition.NotNull)
                    .BuildElement()
                    .StartBuildingChildElement("DependantUpon")
                    .WithElementValue(include.DependantUpon)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .StartBuildingChildElement("SubType")
                    .WithElementValue(include.SubType)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .StartBuildingChildElement("Link")
                    .WithElementValue(include.Link)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .StartBuildingChildElement("Generator")
                    .WithElementValue(include.Generator)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .StartBuildingChildElement("LastGenOutput")
                    .WithElementValue(include.LastGenOutput)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .BuildElement();
            }

            var result = builder.FinishBuilding();
            return result;
        }

        private static string MapElementName(BuildAction buildAction)
        {
            switch (buildAction)
            {
                case BuildAction.Compile:
                {
                    return "Compile";
                }

                case BuildAction.Content:
                {
                    return "Content";
                }

                case BuildAction.EmbeddedResource:
                {
                    return "EmbeddedResource";
                }
                default:
                {
                    throw new Exception("Build action Element: " + buildAction);
                }
            }
        }
    }
}