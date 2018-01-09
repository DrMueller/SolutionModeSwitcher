using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mmu.Sms.DomainServices.Shell.Areas.Domain.Configuration.DataAccess.Entities
{
    public class SolutionModeConfigurationEntity
    {
        public string ConfigurationName { get; set; }
        public string Id { get; set; }
        public List<ProjectReferenceConfigurationEntity> ProjectReferenceConfigurations { get; set; }
        [JsonIgnore]
        public int ProjectReferencesCount => ProjectReferenceConfigurations.Count;
        public string SolutionFilePath { get; set; }
    }
}