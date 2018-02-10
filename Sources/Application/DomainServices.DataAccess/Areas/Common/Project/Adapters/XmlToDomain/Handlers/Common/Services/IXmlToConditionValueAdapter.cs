using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services
{
    public interface IXmlToConditionValueAdapter
    {
        ConditionalValue<TValue> Adapt<TValue>(XElement element);

        ConditionalValue<TValue> AdaptSubElement<TValue>(XElement element, string subElementLocalName);

        Maybe<ConditionalValue<TValue>> TryAdaptingSubElement<TValue>(XContainer container, string subElementLocalName);
    }
}