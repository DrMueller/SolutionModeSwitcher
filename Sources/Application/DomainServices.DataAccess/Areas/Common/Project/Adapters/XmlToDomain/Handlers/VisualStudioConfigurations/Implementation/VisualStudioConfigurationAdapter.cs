using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.VisualStudio;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioConfigurations.Implementation
{
    public class VisualStudioConfigurationAdapter : IVisualStudioConfigurationAdapter
    {
        private readonly IXmlToConditionValueAdapter _xmlToConditionValueAdapter;

        public VisualStudioConfigurationAdapter(IXmlToConditionValueAdapter xmlToConditionValueAdapter)
        {
            _xmlToConditionValueAdapter = xmlToConditionValueAdapter;
        }

        public VisualStudioConfiguration Adapt(XDocument document)
        {
            var version = AdaptVersion(document);
            var toolsPath = AdaptToolsPath(document);

            var result = new VisualStudioConfiguration(version, toolsPath);
            return result;
        }

        private Maybe<VisualStudioToolsPath> AdaptToolsPath(XContainer document)
        {
            var conditionalValueMaybe = _xmlToConditionValueAdapter.TryAdaptingSubElement<string>(document, "VSToolsPath");

            var visualStudioVersion = conditionalValueMaybe.Evaluate(
                f => new VisualStudioToolsPath(f.Condition, f.Value),
                () => null);

            return MaybeFactory.CreateFromNullable(visualStudioVersion);
        }

        private Maybe<VisualStudioVersion> AdaptVersion(XContainer document)
        {
            var conditionalValueMaybe = _xmlToConditionValueAdapter.TryAdaptingSubElement<string>(document, "VisualStudioVersion");

            var visualStudioVersion = conditionalValueMaybe.Evaluate(
                f => new VisualStudioVersion(f.Condition, f.Value),
                () => null);

            return MaybeFactory.CreateFromNullable(visualStudioVersion);
        }
    }
}