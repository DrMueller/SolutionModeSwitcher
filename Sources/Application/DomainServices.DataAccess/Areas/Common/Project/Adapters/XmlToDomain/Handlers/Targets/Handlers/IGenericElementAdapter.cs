using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets.Handlers
{
    public interface IGenericElementAdapter
    {
        GenericXmlElement Adapt(XElement element);
    }
}