using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections.Implementation
{
    public class ProjectConfigurationPlatformsSectionToStringAdapter : SectionToStringAdapterBase, IProjectConfigurationPlatformsSectionToStringAdapter
    {
        public void Adapt(IEnumerable<SolutionProject> solutionProjects, IExtendedStringBuilder sb)
        {
            StartBuilding(sb, "ProjectConfigurationPlatforms", false);
            foreach (var solutionProject in solutionProjects)
            {
                foreach (var config in solutionProject.Configurations)
                {
                    var configLine = $"{solutionProject.ProjectGuid}.{config.ConfigurationKey}.{config.ConfigurationDescrption}";
                    sb.AppendLine(configLine, 2);
                }
            }

            EndBuilding(sb);
        }
    }
}