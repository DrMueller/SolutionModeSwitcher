using System;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.DomainServices.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.Shell.Areas.Infrastructure.Xml
{
    public class XmlParsingService : IXmlParsingService
    {
        public bool? TryParsingSubElementBoolValue(XElement element, string subElementLocalName)
        {
            var parsedString = TryGettingValueOfSubElement(element, subElementLocalName);

            if (!string.IsNullOrEmpty(parsedString))
            {
                return bool.Parse(parsedString);
            }

            return null;
        }

        public T TryParsingSubElementEnumValue<T>(XElement element, string subElementLocalName, T defaultValue)
        {
            var stringValue = TryParsingSubElementStringValue(element, subElementLocalName);

            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            var enumValue = (T)Enum.Parse(typeof(T), stringValue, true);
            return enumValue;
        }

        public string TryParsingSubElementStringValue(XElement element, string subElementLocalName)
        {
            return TryGettingValueOfSubElement(element, subElementLocalName);
        }

        private static string TryGettingValueOfSubElement(XContainer element, string subElementLocalName)
        {
            var subElement = element.Descendants().FirstOrDefault(f => f.Name.LocalName == subElementLocalName);
            return subElement?.Value;
        }
    }
}