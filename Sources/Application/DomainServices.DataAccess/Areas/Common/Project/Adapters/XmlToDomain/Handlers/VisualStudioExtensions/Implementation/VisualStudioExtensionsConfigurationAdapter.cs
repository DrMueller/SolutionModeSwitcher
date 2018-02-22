using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectExtensions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioExtensions.Implementation
{
    public class VisualStudioExtensionsConfigurationAdapter : IVisualStudioExtensionsConfigurationAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public VisualStudioExtensionsConfigurationAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public Maybe<VisualStudioExtensionsConfiguration> Adapt(XDocument document)
        {
            var visualStudioElement = document.Descendants().FirstOrDefault(f => f.Name.LocalName == "VisualStudio");

            if (visualStudioElement == null)
            {
                return MaybeFactory.CreateNone<VisualStudioExtensionsConfiguration>();
            }

            var flavorPropertiesElement = visualStudioElement.Descendants().First(f => f.Name.LocalName == "FlavorProperties");
            var flavorPropertiesGuid = flavorPropertiesElement.Attributes().First(f => f.Name.LocalName == "GUID").Value;

            var webProjectPropertiesElement = flavorPropertiesElement.Descendants().First(f => f.Name.LocalName == "WebProjectProperties");
            var saveServerSettingsInUserFile = _xmlParsingService.ParseSubElementValue<bool>(webProjectPropertiesElement, "SaveServerSettingsInUserFile");

            var config = new VisualStudioExtensionsConfiguration(flavorPropertiesGuid, saveServerSettingsInUserFile);
            return MaybeFactory.CreateSome(config);
        }
    }
}