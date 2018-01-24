using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class ProjectBuildConfigurationEntity
    {
        public string ConfigurationName { get; set; }
        public string OutputPath { get; set; }
        public string PlatformName { get; set; }
        public PlatformTarget PlatformTarget { get; set; }
    }
}