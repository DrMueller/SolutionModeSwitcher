using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectBuild.Implementation
{
    public class ProjectBuildConfigurationAdapter : IProjectBuildConfigurationAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public ProjectBuildConfigurationAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public IReadOnlyCollection<ProjectBuildConfiguration> Adapt(XDocument document)
        {
            var buildConfigElemens = document.Descendants().Where(
                f =>
                    f.Name.LocalName == "PropertyGroup"
                    && f.Parent?.Name.LocalName == "Project"
                    && f.Attributes().Any(a => a.Name.LocalName == "Condition")).ToList();

            var result = buildConfigElemens.Select(AdaptConfiguration).ToList();
            return result;
        }

        private ProjectBuildConfiguration AdaptConfiguration(XElement element)
        {
            var condition = element.Attributes().First(f => f.Name.LocalName == "Condition").Value;
            var debugSymbols = _xmlParsingService.TryParsingSubElementValue<bool>(element, "DebugSymbols");
            var debugType = _xmlParsingService.TryParsingSubElementStringValue(element, "DebugType");
            var optimize = _xmlParsingService.ParseSubElementValue<bool>(element, "Optimize");
            var outputPath = _xmlParsingService.TryParsingSubElementStringValue(element, "OutputPath");
            var defineConstants = _xmlParsingService.TryParsingSubElementStringValue(element, "DefineConstants");
            var errorReport = _xmlParsingService.TryParsingSubElementStringValue(element, "ErrorReport");
            var warningLevel = _xmlParsingService.ParseSubElementValue<int>(element, "WarningLevel");
            var codeAnalysisRuleSet = _xmlParsingService.TryParsingSubElementStringValue(element, "CodeAnalysisRuleSet");
            var runCodeAnalysis = _xmlParsingService.TryParsingSubElementValue<bool>(element, "RunCodeAnalysis");
            var noWarn = _xmlParsingService.TryParsingSubElementValue<int>(element, "NoWarn");
            var usePostSharp = _xmlParsingService.TryParsingSubElementValue<bool>(element, "UsePostSharp");
            var postSharpDisabledMessages = _xmlParsingService.TryParsingSubElementStringValue(element, "PostSharpDisabledMessages");
            var documentationFile = _xmlParsingService.TryParsingSubElementStringValue(element, "DocumentationFile");
            var treatWarningsAsErrors = _xmlParsingService.TryParsingSubElementValue<bool>(element, "TreatWarningsAsErrors");
            var langVersion = _xmlParsingService.ParseSubElementValue<int>(element, "LangVersion");

            var result = new ProjectBuildConfiguration(
                condition,
                debugSymbols,
                debugType,
                optimize,
                outputPath,
                defineConstants,
                errorReport,
                warningLevel,
                codeAnalysisRuleSet,
                runCodeAnalysis,
                noWarn,
                usePostSharp,
                postSharpDisabledMessages,
                documentationFile,
                treatWarningsAsErrors,
                langVersion);

            return result;
        }
    }
}