using System.Collections.Generic;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class ProjectConfigurationFileEntity
    {
        public List<ProjectAssemblyReferenceEntity> AssemblyReferences { get; set; }
        public List<ProjectBuildConfigurationEntity> BuildConfigurations { get; set; }
        public string FilePath { get; set; }
        public ProjectPropertiesConfigurationEntity PropertiesConfiguration { get; set; }
        public List<ProjectReferenceEntity> ProjectReferencs { get; set; }
    }
}