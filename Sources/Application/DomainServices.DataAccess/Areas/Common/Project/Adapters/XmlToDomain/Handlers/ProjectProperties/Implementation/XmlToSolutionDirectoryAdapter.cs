using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
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

        public Maybe<SolutionDirectory> Adapt(XElement element)
        {
            var conditionalValue = _conditionalValueAdapter.TryAdaptingSubElement<string>(element, "SolutionDir");

            return conditionalValue.Evaluate(
                whenSome: cv => MaybeFactory.CreateSome(new SolutionDirectory(cv.Condition, cv.Value)),
                whenNone: MaybeFactory.CreateNone<SolutionDirectory>);
        }
    }
}