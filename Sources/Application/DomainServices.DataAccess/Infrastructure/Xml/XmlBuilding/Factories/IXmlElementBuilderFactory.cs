using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories
{
    public interface IXmlElementBuilderFactory
    {
        IXmlElementBuilder CreateTopLevelElement(XName elementName);
    }
}