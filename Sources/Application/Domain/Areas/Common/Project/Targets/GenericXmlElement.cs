using System;
using System.Collections.Generic;
using System.Linq;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class GenericXmlElement
    {
        public GenericXmlElement(
            string name,
            string value,
            IReadOnlyCollection<GenericXmlAttribute> attributes,
            IReadOnlyCollection<GenericXmlElement> subElements)
        {
            if (!string.IsNullOrEmpty(value) && subElements.Any())
            {
                throw new ArgumentException("Can't have value and SubElements.");
            }

            Name = name;
            Value = value;
            Attributes = attributes;
            SubElements = subElements;
        }

        public IReadOnlyCollection<GenericXmlAttribute> Attributes { get; }
        public string Name { get; }
        public IReadOnlyCollection<GenericXmlElement> SubElements { get; }
        public string Value { get; }
    }
}