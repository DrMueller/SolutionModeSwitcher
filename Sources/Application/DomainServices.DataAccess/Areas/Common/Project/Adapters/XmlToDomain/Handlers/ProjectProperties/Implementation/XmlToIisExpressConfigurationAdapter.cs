using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToIisExpressConfigurationAdapter : IXmlToIisExpressConfigurationAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public XmlToIisExpressConfigurationAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public IisExpressConfiguration Adapt(XElement element)
        {
            var useIisExpress = _xmlParsingService.TryParsingSubElementBoolValue(element, "UseIISExpress") ?? false;
            var sslPort = _xmlParsingService.TryParsingSubElementValue<int>(element, "IISExpressSSLPort");
            var anonymousAuth = _xmlParsingService.TryParsingSubElementStringValue(element, "IISExpressAnonymousAuthentication");
            var windowsAuth = _xmlParsingService.TryParsingSubElementStringValue(element, "IISExpressWindowsAuthentication");
            var useClassicPipelindeMode = _xmlParsingService.TryParsingSubElementBoolValue(element, "IISExpressUseClassicPipelineMode");

            var result = new IisExpressConfiguration(
                useIisExpress,
                sslPort,
                anonymousAuth,
                windowsAuth,
                useClassicPipelindeMode);

            return result;
        }
    }
}