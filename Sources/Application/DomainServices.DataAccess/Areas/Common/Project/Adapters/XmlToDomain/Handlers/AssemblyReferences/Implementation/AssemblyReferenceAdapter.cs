using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;
using Mmu.Sms.DomainServices.Infrastructure.StringParsing;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.AssemblyReferences.Implementation
{
    public class AssemblyReferenceAdapter : IAssemblyReferenceAdapter
    {
        private readonly IStringParsingService _stringParsingService;
        private readonly IXmlParsingService _xmlParsingService;

        public AssemblyReferenceAdapter(IXmlParsingService xmlParsingService, IStringParsingService stringParsingService)
        {
            _xmlParsingService = xmlParsingService;
            _stringParsingService = stringParsingService;
        }

        public IReadOnlyCollection<ProjectAssemblyReference> Adapt(XDocument document)
        {
            var references = document.Descendants().Where(f => f.Name.LocalName == "Reference");
            var result = references.Select(CreateAssemblyReferenceFromElement).ToList();
            return result;
        }

        private ProjectAssemblyReference CreateAssemblyReferenceFromElement(XElement element)
        {
            var includeAttribute = element.Attributes("Include").First();
            var hintPath = _xmlParsingService.TryParsingSubElementStringValue(element, "HintPath");

            var isPrivate = _xmlParsingService.TryParsingSubElementBoolValue(element, "Private");
            var specificVersion = _xmlParsingService.TryParsingSubElementBoolValue(element, "SpecificVersion");

            var includeDefinition = CreateIncludeDefinitionFromAttribute(includeAttribute);
            var result = new ProjectAssemblyReference(includeDefinition, hintPath, isPrivate, specificVersion);
            return result;
        }

        private IncludeDefinition CreateIncludeDefinitionFromAttribute(XAttribute attribute)
        {
            var attributeValue = attribute.Value;
            var assemblyShortName = attributeValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).First();

            const string PossibleEndChars = "[,\"]";
            var version = _stringParsingService.GetValueBetween(attributeValue, "Version=", PossibleEndChars);
            if (version.IndexOf(',') > 0)
            {
                version = version.Substring(0, version.IndexOf(','));
            }

            var publicKeyToken = _stringParsingService.GetValueBetween(attributeValue, "PublicKeyToken=", PossibleEndChars);
            if (publicKeyToken.IndexOf(',') > 0)
            {
                publicKeyToken = publicKeyToken.Substring(0, publicKeyToken.IndexOf(','));
            }

            var processorArchitecture = _stringParsingService.GetValueBetween(attributeValue, "processorArchitecture=", PossibleEndChars);
            if (processorArchitecture.IndexOf(',') > 0)
            {
                processorArchitecture = processorArchitecture.Substring(0, processorArchitecture.IndexOf(','));
            }

            var culture = _stringParsingService.GetValueBetween(attributeValue, "Culture=", PossibleEndChars);
            if (culture.IndexOf(',') > 0)
            {
                culture = culture.Substring(0, culture.IndexOf(','));
            }

            var result = new IncludeDefinition(assemblyShortName, version, culture, publicKeyToken, processorArchitecture);
            return result;
        }
    }
}