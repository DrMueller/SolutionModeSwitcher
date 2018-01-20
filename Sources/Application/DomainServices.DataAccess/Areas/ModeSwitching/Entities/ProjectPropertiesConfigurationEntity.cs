namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class ProjectPropertiesConfigurationEntity
    {
        public string AssemblyName { get; set; }
        public ProjectOutputTypeEntity OutputType { get; set; }
        public string RootNamespace { get; set; }
    }
}