using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToMvcBuildViewAdapter : IXmlToMvcBuildViewAdapter
    {
        private readonly IXmlToConditionValueAdapter _conditionValueAdapter;

        public XmlToMvcBuildViewAdapter(IXmlToConditionValueAdapter conditionValueAdapter)
        {
            _conditionValueAdapter = conditionValueAdapter;
        }

        public IReadOnlyCollection<MvcBuildView> Adapt(XElement element)
        {
            var buildViewElements = element.Descendants().Where(f => f.Name.LocalName == "MvcBuildViews");

            var result = new List<MvcBuildView>();

            foreach (var bvElement in buildViewElements)
            {
                var conditionalVvalue = _conditionValueAdapter.Adapt<bool>(bvElement);
                result.Add(new MvcBuildView(conditionalVvalue.Condition, conditionalVvalue.Value));
            }

            return result;
        }
    }
}