namespace Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah
{
    public class SlowCheetahConfiguration
    {
        public SlowCheetahConfiguration(
            string toolsPath,
            SlowCheetahNugetConfiguration nugetConfiguration,
            SlowCheetahNugetImport nugetImport,
            SlowCheetahTargets targets
        )
        {
            ToolsPath = toolsPath;
            NugetConfiguration = nugetConfiguration;
            NugetImport = nugetImport;
            Targets = targets;
        }

        public SlowCheetahNugetConfiguration NugetConfiguration { get; }
        public SlowCheetahNugetImport NugetImport { get; }
        public SlowCheetahTargets Targets { get; }
        public string ToolsPath { get; }
    }
}