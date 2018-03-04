using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Implementation
{
    public class GlobalEntryToStringAdapter : IGlobalEntryToStringAdapter
    {
        private readonly IGlobalExtensibilitiesSectionToStringAdapter _globalExtensibilitiesSectionAdapter;
        private readonly INestedProjectsSectionToStringAdapter _nestedProjectsSectionAdapter;
        private readonly IProjectConfigurationPlatformsSectionToStringAdapter _projectConfigPlatformsSectionAdapter;
        private readonly ISolutionConfigurationPlatformsSectionToStringAdapter _solutionConfigPlatformsSectionAdapter;
        private readonly ISolutionPropertiesSectionToStringAdapter _solutionPropertiesSectionAdapter;

        public GlobalEntryToStringAdapter(
            ISolutionConfigurationPlatformsSectionToStringAdapter solutionConfigPlatformsSectionAdapter,
            IProjectConfigurationPlatformsSectionToStringAdapter projectConfigPlatformsSectionAdapter,
            ISolutionPropertiesSectionToStringAdapter solutionPropertiesSectionAdapter,
            INestedProjectsSectionToStringAdapter nestedProjectsSectionAdapter,
            IGlobalExtensibilitiesSectionToStringAdapter globalExtensibilitiesSectionAdapter)
        {
            _solutionConfigPlatformsSectionAdapter = solutionConfigPlatformsSectionAdapter;
            _projectConfigPlatformsSectionAdapter = projectConfigPlatformsSectionAdapter;
            _solutionPropertiesSectionAdapter = solutionPropertiesSectionAdapter;
            _nestedProjectsSectionAdapter = nestedProjectsSectionAdapter;
            _globalExtensibilitiesSectionAdapter = globalExtensibilitiesSectionAdapter;
        }

        public void Adapt(SolutionConfigurationFile solutionConfigFile, IExtendedStringBuilder sb)
        {
            sb.AppendLine("Global");
            _solutionConfigPlatformsSectionAdapter.Adapt(solutionConfigFile.SolutionConfigurations, sb);
            _projectConfigPlatformsSectionAdapter.Adapt(solutionConfigFile.SolutionProjects, sb);
            _solutionPropertiesSectionAdapter.Adapt(solutionConfigFile.SolutionProperties, sb);
            _nestedProjectsSectionAdapter.Adapt(solutionConfigFile.SolutionProjects, sb);
            _globalExtensibilitiesSectionAdapter.Adapt(solutionConfigFile.GlobalExtensibilities, sb);
            sb.AppendLine("EndGlobal");
        }
    }
}