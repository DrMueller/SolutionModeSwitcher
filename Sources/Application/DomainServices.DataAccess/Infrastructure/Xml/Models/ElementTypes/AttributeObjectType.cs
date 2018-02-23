using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Models.ElementTypes
{
    public class AttributeObjectType : ObjectType
    {
        protected override object CreateContentToWrite(string name, object value)
        {
            return new XAttribute(name, value);
        }
    }
}