using System.Collections.Generic;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Dtos
{
    public class SolutionModeConfigurationDto
    {
        public SolutionModeConfigurationDto()
        {
            ProjectReferenceConfigurations = new List<ProjectReferenceConfigurationDto>();
        }

        public string ConfigurationName { get; set; }
        public string Id { get; set; }
        public IReadOnlyCollection<ProjectReferenceConfigurationDto> ProjectReferenceConfigurations { get; set; }
        public int ProjectReferencesCount => ProjectReferenceConfigurations.Count;
        public string SolutionFilePath { get; set; }
    }
}