using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services
{
    public interface IXmlElementBuilder
    {
        IXmlElementBuilder BuildElement();

        XElement FinishBuilding();

        IXmlElementBuilder StartBuildingChildElement(string elementName);

        IXmlAttributeBuilder WithAttribute(string name);

        IXmlElementBuilder WithCondition(XmlBuildingCondition condition);

        IXmlElementBuilder WithConditionAttribute(object value);

        IXmlElementBuilder WithElementValue(object value);
    }
}