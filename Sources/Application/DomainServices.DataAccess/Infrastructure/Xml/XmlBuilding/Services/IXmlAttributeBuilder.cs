using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services
{
    public interface IXmlAttributeBuilder
    {
        IXmlElementBuilder BuildAttribute();

        IXmlAttributeBuilder WithAttributeValue(object value);

        IXmlAttributeBuilder WithCondition(XmlBuildingCondition condition);
    }
}