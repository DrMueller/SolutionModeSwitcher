using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Infrastructure.StringParsing;
using Mmu.Sms.DomainServices.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
{
    public class ProjectBuildConfigurationFactory : IProjectBuildConfigurationFactory
    {
        private readonly IStringParsingService _stringParsingService;
        private readonly IXmlParsingService _xmlParsingService;

        public ProjectBuildConfigurationFactory(IXmlParsingService xmlParsingService, IStringParsingService stringParsingService)
        {
            _xmlParsingService = xmlParsingService;
            _stringParsingService = stringParsingService;
        }

        public IReadOnlyCollection<ProjectBuildConfiguration> CreateFromDocument(XDocument document)
        {
            var buildConfigElemens = document.Descendants().Where(
                f =>
                    f.Name.LocalName == ProjectConfigConstants.PropertyGroupTagName
                    && f.Parent?.Name.LocalName == "Project"
                    && f.Attributes().Any(a => a.Name.LocalName == ProjectConfigConstants.ConditionAttributeName)).ToList();

            return buildConfigElemens.Select(CreateFromElement).ToList();
        }

        private ProjectBuildConfiguration CreateFromElement(XElement buildConfigurationElement)
        {
            var outputPath = _xmlParsingService.TryParsingSubElementStringValue(buildConfigurationElement, ProjectConfigConstants.OutputPathTag);
            var platformTarget = _xmlParsingService.TryParsingSubElementEnumValue(buildConfigurationElement, ProjectConfigConstants.PlatformLocalName, PlatformTarget.AnyCpu);

            var platformAndConfigNames = GetConfigurationNameAndPlatformName(buildConfigurationElement);
            var result = new ProjectBuildConfiguration(platformAndConfigNames[0], platformAndConfigNames[1], platformTarget, outputPath);
            return result;
        }

        private string[] GetConfigurationNameAndPlatformName(XElement buildConfigurationElement)
        {
            var conditionAttribute = buildConfigurationElement.Attributes().First(f => f.Name.LocalName == ProjectConfigConstants.ConditionAttributeName);
            var attrValue = conditionAttribute.Value.Trim();
            var configurationAndPlatformName = _stringParsingService.GetValueBetween(attrValue, "== '", "|");
            var result = configurationAndPlatformName.Split('|');

            return result;
        }
    }
}