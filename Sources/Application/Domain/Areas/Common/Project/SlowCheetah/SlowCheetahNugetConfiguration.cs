namespace Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah
{
    public class SlowCheetahNugetConfiguration
    {
        public SlowCheetahNugetConfiguration(string condition, bool enableImportFromNuget)
        {
            Condition = condition;
            EnableImportFromNuget = enableImportFromNuget;
        }

        public string Condition { get; }
        public bool EnableImportFromNuget { get; }
    }
}