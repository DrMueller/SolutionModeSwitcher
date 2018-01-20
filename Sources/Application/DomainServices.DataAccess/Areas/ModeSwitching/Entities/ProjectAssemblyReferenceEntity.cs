namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class ProjectAssemblyReferenceEntity
    {
        public string HintPath { get; set; }
        public IncludeDefinitionEntity IncludeDefinition { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? SpecificVersion { get; set; }
    }
}