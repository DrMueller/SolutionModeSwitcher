using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;
using Mmu.Sms.DomainServices.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
{
    public class ProjectPropertiesConfigurationFactory : IProjectPropertiesConfigurationFactory
    {
        private readonly IXmlParsingService _xmlParsingService;

        public ProjectPropertiesConfigurationFactory(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public ProjectPropertiesConfiguration CreateFromDocument(XDocument document)
        {
            var configurationElement = document.Descendants().First(f => f.Name.LocalName == ProjectConfigConstants.ConfigurationTagName).Parent;

            var rootNamespace = _xmlParsingService.TryParsingSubElementStringValue(configurationElement, ProjectConfigConstants.RootNamespaceLocalName);
            var assemblyName = _xmlParsingService.TryParsingSubElementStringValue(configurationElement, ProjectConfigConstants.AssemblyNameLocalName);
            var outputTypeString = _xmlParsingService.TryParsingSubElementStringValue(configurationElement, ProjectConfigConstants.OutputTypeLocalName);
            var outputType = ProjectOutputType.Parse(outputTypeString);

            var result = new ProjectPropertiesConfiguration(rootNamespace, assemblyName, outputType);
            return result;
        }
    }
}