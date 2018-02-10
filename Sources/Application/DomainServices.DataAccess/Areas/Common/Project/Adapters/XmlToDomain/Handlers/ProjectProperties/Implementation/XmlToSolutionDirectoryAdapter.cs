using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToSolutionDirectoryAdapter : IXmlToSolutionDirectoryAdapter
    {
        private readonly IXmlToConditionValueAdapter _conditionalValueAdapter;

        public XmlToSolutionDirectoryAdapter(IXmlToConditionValueAdapter conditionalValueAdapter)
        {
            _conditionalValueAdapter = conditionalValueAdapter;
        }

        public SolutionDirectory Adapt(XElement element)
        {
            var conditionalValue = _conditionalValueAdapter.AdaptSubElement<string>(element, "SolutionDir");
            var result = new SolutionDirectory(conditionalValue.Condition, conditionalValue.Value);

            return result;
        }
    }
}