using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToProjectOutputTypeAdapter : IXmlToProjectOutputTypeAdapter
    {
        private readonly IProjectOutputTypeFactory _projectOutputTypeFactory;
        private readonly IXmlParsingService _xmlParsingService;

        public XmlToProjectOutputTypeAdapter(IXmlParsingService xmlParsingService, IProjectOutputTypeFactory projectOutputTypeFactory)
        {
            _xmlParsingService = xmlParsingService;
            _projectOutputTypeFactory = projectOutputTypeFactory;
        }

        public ProjectOutputType Adapt(XElement element)
        {
            var outputTypeValue = _xmlParsingService.TryParsingSubElementStringValue(element, "OutputType");
            var result = _projectOutputTypeFactory.CreateFromDescription(outputTypeValue);

            return result;
        }
    }
}