using System.Linq;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Implementation
{
    public class StringToSolutionConfigurationFileAdapter : IStringToSolutionConfigurationFileAdapter
    {
        private readonly IFileProxy _fileProxy;
        private readonly IStringToGlobalExtensibilitiesAdapter _globalExtensibilitiesAdapter;
        private readonly IStringToHeadingAdapter _headingAdapter;
        private readonly IStringToSolutionConfigurationAdapter _solutionConfigAdapter;
        private readonly IStringToSolutionProjectAdapter _solutionProjectAdapter;
        private readonly IStringToSolutionPropertiesAdapter _solutionPropertiesAdapter;

        public StringToSolutionConfigurationFileAdapter(
            IStringToHeadingAdapter headingAdapter,
            IStringToSolutionProjectAdapter solutionProjectAdapter,
            IStringToSolutionConfigurationAdapter solutionConfigAdapter,
            IStringToSolutionPropertiesAdapter solutionPropertiesAdapter,
            IStringToGlobalExtensibilitiesAdapter globalExtensibilitiesAdapter,
            IFileProxy fileProxy)
        {
            _headingAdapter = headingAdapter;
            _solutionProjectAdapter = solutionProjectAdapter;
            _solutionConfigAdapter = solutionConfigAdapter;
            _solutionPropertiesAdapter = solutionPropertiesAdapter;
            _globalExtensibilitiesAdapter = globalExtensibilitiesAdapter;
            _fileProxy = fileProxy;
        }

        public SolutionConfigurationFile Adapt(string filePath)
        {
            var solutionDataLines = _fileProxy.ReadAllLines(filePath).ToList();
            var headingElement = _headingAdapter.Adapt(solutionDataLines);
            var solutionProjects = _solutionProjectAdapter.Adapt(filePath, solutionDataLines);
            var solutionConfigs = _solutionConfigAdapter.Adapt(filePath);
            var solutionProperties = _solutionPropertiesAdapter.Adapt(solutionDataLines);
            var globalExtensibilities = _globalExtensibilitiesAdapter.Adapt(solutionDataLines);

            var result = new SolutionConfigurationFile(
                filePath,
                headingElement,
                solutionProperties,
                solutionProjects,
                solutionConfigs,
                globalExtensibilities);

            return result;
        }
    }
}