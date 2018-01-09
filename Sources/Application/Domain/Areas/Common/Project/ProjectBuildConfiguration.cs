namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectBuildConfiguration
    {
        public const string ConfigurationNameDebug = "Debug";

        public ProjectBuildConfiguration(
            string configurationName,
            string platformName,
            PlatformTarget platformTarget,
            string outputPath)
        {
            ConfigurationName = configurationName;
            PlatformName = platformName;
            PlatformTarget = platformTarget;
            OutputPath = outputPath;
        }

        public string ConfigurationName { get; }
        public string PlatformName { get; }
        public string OutputPath { get; }
        public PlatformTarget PlatformTarget { get; }
    }
}