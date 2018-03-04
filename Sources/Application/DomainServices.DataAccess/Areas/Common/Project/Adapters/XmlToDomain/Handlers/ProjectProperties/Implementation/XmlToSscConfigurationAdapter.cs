using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToSscConfigurationAdapter : IXmlToSscConfigurationAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public XmlToSscConfigurationAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public SccConfiguration Adapt(XElement element)
        {
            var projectName = _xmlParsingService.TryParsingSubElementStringValue(element, "SccProjectName");
            var localPath = _xmlParsingService.TryParsingSubElementStringValue(element, "SccLocalPath");
            var auxPath = _xmlParsingService.TryParsingSubElementStringValue(element, "SccAuxPath");
            var provider = _xmlParsingService.TryParsingSubElementStringValue(element, "SccProvider");

            var result = new SccConfiguration(
                projectName,
                localPath,
                auxPath,
                provider);

            return result;
        }
    }
}