using System.Collections.Generic;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class SolutionModeShadowCopyEntity
    {
        public string ConfigurationId { get; set; }
        public List<ProjectConfigurationFileEntity> ProjectConfigurationFiles { get; set; }
        public SolutionConfigurationFileEntity SolutionConfigurationFile { get; set; }
    }
}