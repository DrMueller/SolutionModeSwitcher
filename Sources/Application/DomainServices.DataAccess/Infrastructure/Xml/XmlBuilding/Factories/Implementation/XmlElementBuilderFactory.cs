using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Services.Implementation;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories.Implementation
{
    public class XmlElementBuilderFactory : IXmlElementBuilderFactory
    {
        public IXmlElementBuilder CreateTopLevelElement(XName elementName)
        {
            return new XmlElementBuilder(null, null, elementName);
        }
    }
}