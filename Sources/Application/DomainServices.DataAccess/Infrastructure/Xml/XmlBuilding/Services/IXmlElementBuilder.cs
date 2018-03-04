using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services
{
    public interface IXmlElementBuilder
    {
        IXmlElementBuilder BuildElement();

        IXmlElementBuilder StartBuildingChildElement(string elementName);

        IXmlElementBuilder WithCondition(XmlBuildingCondition condition);

        IXmlAttributeBuilder WithAttribute(string name);

        IXmlElementBuilder WithConditionAttribute(object value);

        IXmlElementBuilder WithElementValue(object value);

        XElement FinishBuilding();
    }
}