using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public class SolutionConfigurationPlatformsSectionToStringAdapter : SectionToStringAdapterBase, ISolutionConfigurationPlatformsSectionToStringAdapter
    {
        public void Adapt(IEnumerable<SolutionConfiguration> solutionConfigs, IExtendedStringBuilder sb)
        {
            StartBuilding(sb, "SolutionConfigurationPlatforms", true);
            const string SolutionConfigTemplate = "{0} = {1}|{2}";
            foreach (var solutionConfig in solutionConfigs)
            {
                var solutionConfigString = string.Format(
                    SolutionConfigTemplate,
                    solutionConfig.FullName,
                    solutionConfig.ConfigurationName,
                    solutionConfig.PlatformName);

                sb.AppendLine(solutionConfigString, 2);
            }

            EndBuilding(sb);
        }
    }
}