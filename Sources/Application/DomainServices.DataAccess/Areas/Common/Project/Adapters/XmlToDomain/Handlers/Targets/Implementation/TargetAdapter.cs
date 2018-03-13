using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets.Handlers;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets.Implementation
{
    public class TargetAdapter : ITargetAdapter
    {
        private readonly IGenericElementAdapter _genericElementAdapter;

        public TargetAdapter(IGenericElementAdapter genericElementAdapter)
        {
            _genericElementAdapter = genericElementAdapter;
        }

        public IReadOnlyCollection<Target> Adapt(XDocument document)
        {
            var result = document.Descendants().Where(f => f.Name.LocalName == "Target").Select(AdaptFromElement).ToList();
            return result;
        }

        private Target AdaptFromElement(XElement element)
        {
            var name = element.Attributes().First(f => f.Name.LocalName == "Name").Value;
            var condition = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "Condition")?.Value ?? string.Empty;
            var beforeTargets = element.Attributes().FirstOrDefault(f => f.Name.LocalName == "BeforeTargets")?.Value ?? string.Empty;

            var subElements = element.Elements().Select(_genericElementAdapter.Adapt).ToList();

            var result = new Target(
                name,
                condition,
                beforeTargets,
                subElements);

            return result;
        }
    }
}