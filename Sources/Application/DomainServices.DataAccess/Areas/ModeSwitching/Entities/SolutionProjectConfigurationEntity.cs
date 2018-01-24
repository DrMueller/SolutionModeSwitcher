namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class SolutionProjectConfigurationEntity
    {
        public string ConfigurationName { get; set; }
        public string FullName { get; set; }
        public bool IncludeInBuild { get; set; }
        public string Key { get; set; }
        public string PlatformName { get; set; }
    }
}