using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Services;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.SlowCheetah.Implementation
{
    public class SlowCheetahConfigurationAdapter : ISlowCheetahConfigurationAdapter
    {
        private readonly IXmlToConditionValueAdapter _conditionValueAdapter;
        private readonly IXmlParsingService _xmlParsingService;

        public SlowCheetahConfigurationAdapter(IXmlParsingService xmlParsingService, IXmlToConditionValueAdapter conditionValueAdapter)
        {
            _xmlParsingService = xmlParsingService;
            _conditionValueAdapter = conditionValueAdapter;
        }

        public Maybe<SlowCheetahConfiguration> Adapt(XDocument document)
        {
            var parentElement = document.Descendants().FirstOrDefault(
                f =>
                    f.Attributes().Any(a => a.Name.LocalName == "Label" && a.Value == "SlowCheetah"));

            if (parentElement == null)
            {
                return MaybeFactory.CreateNone<SlowCheetahConfiguration>();
            }

            var toolsPath = _xmlParsingService.TryParsingSubElementStringValue(parentElement, "SlowCheetahToolsPath");
            var nugetConfig = AdaptNugetConfiguration(parentElement);
            var nugetImport = AdaptNugetImport(parentElement);
            var targets = AdaptTargets(parentElement);

            var config = new SlowCheetahConfiguration(toolsPath, nugetConfig, nugetImport, targets);
            return MaybeFactory.CreateSome(config);
        }

        private SlowCheetahNugetConfiguration AdaptNugetConfiguration(XElement element)
        {
            var conditionValue = _conditionValueAdapter.AdaptSubElement<bool>(element, "SlowCheetah_EnableImportFromNuGet");
            var result = new SlowCheetahNugetConfiguration(conditionValue.Condition, conditionValue.Value);
            return result;
        }

        private SlowCheetahNugetImport AdaptNugetImport(XElement element)
        {
            var conditionValue = _conditionValueAdapter.AdaptSubElement<string>(element, "SlowCheetah_NuGetImportPath");
            var result = new SlowCheetahNugetImport(conditionValue.Condition, conditionValue.Value);
            return result;
        }

        private SlowCheetahTargets AdaptTargets(XElement element)
        {
            var conditionValue = _conditionValueAdapter.AdaptSubElement<string>(element, "SlowCheetahTargets");
            var result = new SlowCheetahTargets(conditionValue.Condition, conditionValue.Value);
            return result;
        }
    }
}