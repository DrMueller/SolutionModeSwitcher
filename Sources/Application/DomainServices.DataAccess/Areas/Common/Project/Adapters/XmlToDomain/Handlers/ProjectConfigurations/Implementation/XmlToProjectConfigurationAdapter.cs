using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectConfigurations;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectConfigurations.Implementation
{
    public class XmlToProjectConfigurationAdapter : IXmlToProjectConfigurationAdapter
    {
        public ProjectConfiguration Adapt(XDocument document)
        {
            var projectElement = document.Elements().Single(f => f.Name.LocalName == "Project");

            var toolsVersion = projectElement.Attributes().Single(f => f.Name.LocalName == "ToolsVersion").Value;
            var defaultTargets = projectElement.Attributes().Single(f => f.Name.LocalName == "DefaultTargets").Value;
            var xmlNamespace = projectElement.Attributes().Single(f => f.Name.LocalName == "xmlns").Value;

            var result = new ProjectConfiguration(toolsVersion, defaultTargets, xmlNamespace);
            return result;
        }
    }
}