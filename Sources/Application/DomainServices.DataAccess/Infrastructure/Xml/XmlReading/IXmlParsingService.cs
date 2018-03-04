using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading
{
    public interface IXmlParsingService
    {
        T ParseSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct;

        bool? TryParsingSubElementBoolValue(XElement element, string subElementLocalName);

        T TryParsingSubElementEnumValue<T>(XElement element, string subElementLocalName, T defaultValue);

        string TryParsingSubElementStringValue(XElement element, string subElementLocalName);

        T? TryParsingSubElementValue<T>(XElement element, string subElementLocalName)
            where T : struct;
    }
}