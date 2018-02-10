using System;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services.Implementation
{
    public class XmlToConditionValueAdapter : IXmlToConditionValueAdapter
    {
        public ConditionalValue<TValue> Adapt<TValue>(XElement element)
        {
            var condition = element.Attributes().First(f => f.Name == "Condition").Value;

            var valueString = element.Value;

            var value = (TValue)Convert.ChangeType(valueString, typeof(TValue));
            var result = new ConditionalValue<TValue>(condition, value);
            return result;
        }

        public ConditionalValue<TValue> AdaptSubElement<TValue>(XElement element, string subElementLocalName)
        {
            var subElement = element.Descendants().First(f => f.Name.LocalName == subElementLocalName);
            return Adapt<TValue>(subElement);
        }

        public Maybe<ConditionalValue<TValue>> TryAdaptingSubElement<TValue>(XContainer container, string subElementLocalName)
        {
            var subElement = container.Descendants().FirstOrDefault(f => f.Name.LocalName == subElementLocalName);

            if (subElement == null)
            {
                return MaybeFactory.CreateNone<ConditionalValue<TValue>>();
            }

            var conditionalValue = Adapt<TValue>(subElement);
            return MaybeFactory.CreateSome(conditionalValue);
        }
    }
}