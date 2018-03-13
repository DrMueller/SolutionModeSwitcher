using System.Collections.Generic;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class Target
    {
        public Target(
            string name,
            string condition,
            string beforeTargets,
            IReadOnlyCollection<GenericXmlElement> elements
        )
        {
            Name = name;
            Condition = condition;
            BeforeTargets = beforeTargets;
            Elements = elements;
        }

        public string BeforeTargets { get; }
        public string Condition { get; }
        public IReadOnlyCollection<GenericXmlElement> Elements { get; }
        public string Name { get; }
    }
}