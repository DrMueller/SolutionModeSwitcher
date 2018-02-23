using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Models.ElementTypes;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml
{
    public interface IXmlWritingService
    {
        void ConditionallyAdd<T>(ObjectType objectType, XElement targetElement, string name, T value);
    }
}