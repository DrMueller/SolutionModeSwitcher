using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectProperties.Implementation
{
    public class ProjectPropertiesConfigurationToXmlAdapter : IProjectPropertiesConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public ProjectPropertiesConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var prop = projectConfigFile.ProjectPropertiesConfiguration;

            var elementBuilder = _xmlElementBuilderFactory.CreateTopLevelElement("PropertyGroup")
                .StartBuildingChildElement("Configuration")
                .WithElementValue(prop.ConfigurationName)
                .WithConditionAttribute(" '$(Configuration)' == '' ")
                .BuildElement()
                .StartBuildingChildElement("Platform")
                .WithConditionAttribute(" '$(Platform)' == '' ")
                .WithElementValue(prop.PlatformName)
                .BuildElement()
                .StartBuildingChildElement("ProductVersion")
                .WithElementValue(prop.ProductVersion)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("SchemaVersion")
                .WithElementValue(prop.SchemaVersion)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("ProjectGuid")
                .WithElementValue(prop.ProjectGuid)
                .BuildElement()
                .StartBuildingChildElement("ProjectTypeGuids")
                .WithElementValue(prop.ProjectTypeGuids)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("OutputType")
                .WithElementValue(prop.OutputType.Description)
                .BuildElement()
                .StartBuildingChildElement("AppDesignerFolder")
                .WithElementValue(prop.AppDesignerFolder)
                .BuildElement()
                .StartBuildingChildElement("RootNamespace")
                .WithElementValue(prop.AppDesignerFolder)
                .BuildElement()
                .StartBuildingChildElement("AssemblyName")
                .WithElementValue(prop.AssemblyName)
                .BuildElement()
                .StartBuildingChildElement("TargetFrameworkVersion")
                .WithElementValue(prop.TargetFrameworkVersion)
                .BuildElement()
                .StartBuildingChildElement("FileAlignment")
                .WithElementValue(prop.FileAlignment)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement();

            foreach (var mvcBuildView in prop.MvcBuildViews)
            {
                elementBuilder.StartBuildingChildElement("MvcBuildViews")
                    .WithAttribute("ConditioN")
                    .WithAttributeValue(mvcBuildView.Condition)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildAttribute()
                    .WithElementValue(mvcBuildView.BuildViews);
            }

            AppendIisConfiguration(elementBuilder, prop.IisExpressConfiguration);
            elementBuilder = elementBuilder.StartBuildingChildElement("SccProjectName")
                .WithElementValue(prop.SccConfiguration.SccProjectName)
                .BuildElement()
                .StartBuildingChildElement("SccLocalPath")
                .WithElementValue(prop.SccConfiguration.SccLocalPath)
                .BuildElement()
                .StartBuildingChildElement("SccAuxPath")
                .WithElementValue(prop.SccConfiguration.SccAuxPath)
                .BuildElement()
                .StartBuildingChildElement("SccProvider")
                .WithElementValue(prop.SccConfiguration.SccProvider)
                .BuildElement();

            prop.SolutionDirectory.Evaluate(
                solutionDir =>
                    elementBuilder.StartBuildingChildElement("SolutionDir")
                        .WithElementValue(solutionDir.Path)
                        .WithConditionAttribute(solutionDir.Condition)
                        .BuildElement());

            elementBuilder.StartBuildingChildElement("RestorePackages")
                .WithElementValue(prop.RestorePackages)
                .BuildElement()
                .StartBuildingChildElement("WebGreaseLibPath")
                .WithElementValue(prop.WebGreaseLibPath)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("UseGlobalApplicationHostFile")
                .WithElementValue(prop.UseGlobalApplicationHostFile)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("DontImportPostSharp")
                .WithElementValue(prop.DoNotImportPostSharp)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("TargetFrameworkProfile")
                .WithElementValue(prop.TargetFrameworkProfile)
                .BuildElement()
                .StartBuildingChildElement("LangVersion")
                .WithElementValue(prop.LangVersion)
                .WithCondition(XmlBuildingCondition.NotNull)
                .BuildElement()
                .StartBuildingChildElement("NuGetPackageImportStamp")
                .WithElementValue(prop.NugetPackageImportstamp)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement();

            var result = elementBuilder.FinishBuilding();

            return result;
        }

        private static void AppendIisConfiguration(IXmlElementBuilder elementBuilder, Maybe<IisExpressConfiguration> iisExpressConfig)
        {
            iisExpressConfig.Evaluate(
                config =>
                {
                    elementBuilder.StartBuildingChildElement("UseIISExpress")
                        .WithElementValue(config.UseIisExpress)
                        .BuildElement()
                        .StartBuildingChildElement("IISExpressSSLPort")
                        .WithElementValue(config.SslPort)
                        .BuildElement()
                        .StartBuildingChildElement("IISExpressAnonymousAuthentication")
                        .WithElementValue(config.AnonymousAuthentication)
                        .BuildElement()
                        .StartBuildingChildElement("IISExpressWindowsAuthentication")
                        .WithElementValue(config.WindowsAuthentication)
                        .BuildElement()
                        .StartBuildingChildElement("IISExpressUseClassicPipelineMode")
                        .WithElementValue(config.UseClassicPipelineMode)
                        .BuildElement();
                });
        }
    }
}