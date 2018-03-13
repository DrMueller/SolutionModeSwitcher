using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Targets.Handlers.Implementation
{
    public class GenericElementToXmlAdapter : IGenericElementToXmlAdapter
    {
        public XElement Adapt(GenericXmlElement genericElement)
        {
            var result = new XElement(genericElement.Name);
            foreach (var attr in genericElement.Attributes)
            {
                result.Add(new XAttribute(attr.Name, attr.Value));
            }

            result.SetValue(genericElement.Value);

            foreach (var subElement in genericElement.SubElements)
            {
                result.Add(Adapt(subElement));
            }

            return result;
        }
    }
}