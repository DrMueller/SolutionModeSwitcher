using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectBuild;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectBuild.Implementation
{
    public class ProjectBuildConfigurationToXmlAdapter : IProjectBuildConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public ProjectBuildConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.BuildConfigurations.Select(AdaptElement).ToList();
            return result;
        }

        private XElement AdaptElement(ProjectBuildConfiguration projectBuildConfig)
        {
            var builder = _xmlElementBuilderFactory.CreateTopLevelElement("PropertyGroup")
                .WithConditionAttribute(projectBuildConfig.Condition)
                .StartBuildingChildElement("DebugSymbols")
                .WithElementValue(projectBuildConfig.DebugSymbols)
                .WithCondition(XmlBuildingCondition.NotNull)
                .BuildElement()
                .StartBuildingChildElement("DebugType")
                .WithElementValue(projectBuildConfig.DebugType)
                .BuildElement()
                .StartBuildingChildElement("Optimize")
                .WithElementValue(projectBuildConfig.Optimize)
                .BuildElement()
                .StartBuildingChildElement("OutputPath")
                .WithElementValue(projectBuildConfig.OutputPath)
                .BuildElement()
                .StartBuildingChildElement("DefineConstants")
                .WithElementValue(projectBuildConfig.DefineConstants)
                .BuildElement()
                .StartBuildingChildElement("ErrorReport")
                .WithElementValue(projectBuildConfig.ErrorReport)
                .BuildElement()
                .StartBuildingChildElement("WarningLevel")
                .WithElementValue(projectBuildConfig.WarningLevel)
                .BuildElement()
                .StartBuildingChildElement("RunCodeAnalysis")
                .WithElementValue(projectBuildConfig.RunCodeAnalysis)
                .BuildElement()
                .StartBuildingChildElement("CodeAnalysisRuleSet")
                .WithElementValue(projectBuildConfig.CodeAnalysisRuleSet)
                .BuildElement()
                .StartBuildingChildElement("UsePostSharp")
                .WithElementValue(projectBuildConfig.UsePostSharp)
                .WithCondition(XmlBuildingCondition.NotNull)
                .BuildElement()
                .StartBuildingChildElement("PostSharpDisabledMessages")
                .WithElementValue(projectBuildConfig.PostSharpDisabledMessages)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildElement()
                .StartBuildingChildElement("TreatWarningsAsErrors")
                .WithElementValue(projectBuildConfig.TreatWarningsAsErrors)
                .WithCondition(XmlBuildingCondition.NotNull)
                .BuildElement()
                .StartBuildingChildElement("LangVersion")
                .WithElementValue(projectBuildConfig.LangVersion)
                .WithCondition(XmlBuildingCondition.NotNull)
                .BuildElement();

            var result = builder.FinishBuilding();
            return result;
        }
    }
}