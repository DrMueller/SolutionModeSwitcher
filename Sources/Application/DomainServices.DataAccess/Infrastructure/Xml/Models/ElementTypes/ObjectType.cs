using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Models.ElementTypes
{
    public abstract class ObjectType
    {
        public static ObjectType Attribute => new AttributeObjectType();

        public void WriteContent(XElement targetElement, string name, object value)
        {
            var elementToWrite = CreateContentToWrite(name, value);
            targetElement.Add(elementToWrite);
        }

        protected abstract object CreateContentToWrite(string name, object value);
    }
}