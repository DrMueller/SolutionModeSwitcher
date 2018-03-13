using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.SlowCheetah.Implementation
{
    public class SlowCheetahConfigurationToXmlAdapter : ISlowCheetahConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public SlowCheetahConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public Maybe<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.SlowCheetaConfiguration.Evaluate(
                config =>
                {
                    var element = _xmlElementBuilderFactory.CreateTopLevelElement("PropertyGroup")
                        .WithAttribute("Label")
                        .WithAttributeValue("SlowCheetah")
                        .BuildAttribute()
                        .StartBuildingChildElement("SlowCheetahToolsPath")
                        .WithElementValue(config.ToolsPath)
                        .BuildElement()
                        .StartBuildingChildElement("SlowCheetah_EnableImportFromNuGet")
                        .WithConditionAttribute(config.NugetConfiguration.Condition)
                        .WithElementValue(config.NugetConfiguration.EnableImportFromNuget)
                        .BuildElement()
                        .StartBuildingChildElement("SlowCheetah_NuGetImportPath")
                        .WithConditionAttribute(config.NugetImport.Condition)
                        .WithElementValue(config.NugetImport.ImportPath)
                        .BuildElement()
                        .StartBuildingChildElement("SlowCheetahTargets")
                        .WithConditionAttribute(config.Targets.Condition)
                        .WithElementValue(config.Targets.Targets)
                        .BuildElement()
                        .FinishBuilding();

                    return MaybeFactory.CreateSome(element);
                },
                MaybeFactory.CreateNone<XElement>);

            return result;
        }
    }
}