using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.Infrastructure.Xml
{
    public interface IXmlParsingService
    {
        bool? TryParsingSubElementBoolValue(XElement element, string subElementLocalName);

        T TryParsingSubElementEnumValue<T>(XElement element, string subElementLocalName, T defaultValue);

        string TryParsingSubElementStringValue(XElement element, string subElementLocalName);
    }
}