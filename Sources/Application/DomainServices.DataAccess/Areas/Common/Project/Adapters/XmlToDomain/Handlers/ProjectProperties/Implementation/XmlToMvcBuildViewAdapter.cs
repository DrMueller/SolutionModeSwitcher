using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToMvcBuildViewAdapter : IXmlToMvcBuildViewAdapter
    {
        public IReadOnlyCollection<MvcBuildView> Adapt(XElement element)
        {
            var buildViewElements = element.Descendants().Where(f => f.Name.LocalName == "MvcBuildViews");

            var result = new List<MvcBuildView>();

            foreach (var bvElement in buildViewElements)
            {
                var condition = bvElement.Attributes().FirstOrDefault(f => f.Name.LocalName == "Condition")?.Value;
                result.Add(new MvcBuildView(condition, bool.Parse(bvElement.Value)));
            }

            return result;
        }
    }
}