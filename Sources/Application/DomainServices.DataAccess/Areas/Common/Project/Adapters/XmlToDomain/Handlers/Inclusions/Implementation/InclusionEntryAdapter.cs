using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions.Implementation
{
    public class InclusionEntryAdapter : IInclusionEntryAdapter
    {
        private readonly IBuildActionAdapter _buildActionAdapter;
        private readonly ICopyToOutputDirectoryTypeAdapter _copyToOutputDirectoryTypeAdapter;
        private readonly IXmlParsingService _xmlParsingService;

        //<Compile Include = "Helpers\Templates\BootstrapControls.generated.cs" >
        //< AutoGen > True </ AutoGen >
        //< DesignTime > True </ DesignTime >
        //< DependentUpon > BootstrapControls.cshtml </ DependentUpon >
        //</ Compile >

        public InclusionEntryAdapter(
            IXmlParsingService xmlParsingService,
            IBuildActionAdapter buildActionAdapter,
            ICopyToOutputDirectoryTypeAdapter copyToOutputDirectoryTypeAdapter)
        {
            _xmlParsingService = xmlParsingService;
            _buildActionAdapter = buildActionAdapter;
            _copyToOutputDirectoryTypeAdapter = copyToOutputDirectoryTypeAdapter;
        }

        public IReadOnlyCollection<InclusionEntry> Adapt(XDocument document)
        {
            var includeElements = document.Descendants().Where(CheckIfHasIncludeAttribute);
            var result = includeElements.Select(AdaptFromElement).ToList();

            return result;
        }

        private InclusionEntry AdaptFromElement(XElement element)
        {
            var autoGen = _xmlParsingService.TryParsingSubElementValue<bool>(element, "AutoGen");
            var designTime = _xmlParsingService.TryParsingSubElementValue<bool>(element, "DesignTime");
            var excludeFromStyleCop = _xmlParsingService.TryParsingSubElementValue<bool>(element, "ExcludeFromStyleCop");
            var dependantUpon = _xmlParsingService.TryParsingSubElementStringValue(element, "DependentUpon");
            var subType = _xmlParsingService.TryParsingSubElementStringValue(element, "SubType");
            var link = _xmlParsingService.TryParsingSubElementStringValue(element, "Link");
            var generator = _xmlParsingService.TryParsingSubElementStringValue(element, "Generator");
            var lastGenOutput = _xmlParsingService.TryParsingSubElementStringValue(element, "LastGenOutput");
            var outputType = _copyToOutputDirectoryTypeAdapter.Adapt(element);
            var includePath = element.Attributes().First(f => f.Name == "Include").Value;
            var buildAction = _buildActionAdapter.Adapt(element);

            var result = new InclusionEntry(
                includePath,
                buildAction,
                link,
                outputType,
                subType,
                excludeFromStyleCop,
                designTime,
                autoGen,
                dependantUpon,
                generator,
                lastGenOutput);

            return result;
        }

        private static bool CheckIfHasIncludeAttribute(XElement element)
        {
            var includeAttr = element.Attributes().FirstOrDefault(f => f.Name == "Include");
            return includeAttr != null;
        }
    }
}