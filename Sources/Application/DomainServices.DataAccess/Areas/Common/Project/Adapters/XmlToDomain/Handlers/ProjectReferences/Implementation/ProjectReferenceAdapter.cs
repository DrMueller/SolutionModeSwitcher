using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectReferences.Implementation
{
//<ProjectReference Include = "..\Assets\Fifa.Ifes.Assets.csproj" >
//< Project >{7aa549c9-17c3-4037-83b8-662af6961619
//}</Project>
//<Name>Fifa.Ifes.Assets</Name>
//</ProjectReference>

    public class ProjectReferenceAdapter : IProjectReferenceAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public ProjectReferenceAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public IReadOnlyCollection<ProjectReference> Adapt(XDocument document)
        {
            var projectReferenceElements = document.Descendants().Where(f => f.Name.LocalName == "ProjectReference");
            var result = projectReferenceElements.Select(AdaptFromElement).ToList();
            return result;
        }

        private ProjectReference AdaptFromElement(XElement element)
        {
            var includePath = element.Attributes().First(f => f.Name.LocalName == "Include").Value;
            var projectGuid = _xmlParsingService.TryParsingSubElementStringValue(element, "Project");
            var assemblyName = _xmlParsingService.TryParsingSubElementStringValue(element, "Name");

            var result = new ProjectReference(projectGuid, includePath, assemblyName);
            return result;
        }
    }
}