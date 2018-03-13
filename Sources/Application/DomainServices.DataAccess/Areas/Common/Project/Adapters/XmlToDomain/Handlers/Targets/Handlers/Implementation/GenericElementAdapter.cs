using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets.Handlers.Implementation
{
    public class GenericElementAdapter : IGenericElementAdapter
    {
        public GenericXmlElement Adapt(XElement element)
        {
            var name = element.Name.LocalName;
            var value = element.HasElements ? string.Empty : element.Value;

            var attributes = AdaptAttributes(element);

            var subXmlElements = new List<GenericXmlElement>();
            if (element.HasElements)
            {
                subXmlElements.AddRange(element.Elements().Select(Adapt));
            }

            var result = new GenericXmlElement(name, value, attributes, subXmlElements);
            return result;
        }

        private static IReadOnlyCollection<GenericXmlAttribute> AdaptAttributes(XElement element)
        {
            var result = element.Attributes().Select(attr => new GenericXmlAttribute(attr.Name.LocalName, attr.Value)).ToList();
            return result;
        }
    }
}