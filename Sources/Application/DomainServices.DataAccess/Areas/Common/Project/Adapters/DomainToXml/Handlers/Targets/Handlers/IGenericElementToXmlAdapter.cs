using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Targets.Handlers
{
    public interface IGenericElementToXmlAdapter
    {
        XElement Adapt(GenericXmlElement genericElement);
    }
}