using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution._legacy
{
    public class SolutionProjectConfiguration
    {
        public SolutionProjectConfiguration(
            string key,
            string platformName,
            bool includeInBuild,
            string fullName,
            string configurationName)
        {
            Guard.StringNotNullOrEmpty(() => key);
            Guard.StringNotNullOrEmpty(() => platformName);
            Guard.StringNotNullOrEmpty(() => fullName);
            Guard.StringNotNullOrEmpty(() => configurationName);

            Key = key;
            PlatformName = platformName;
            IncludeInBuild = includeInBuild;
            FullName = fullName;
            ConfigurationName = configurationName;
        }

        public string ConfigurationName { get; }
        public string FullName { get; }
        public bool IncludeInBuild { get; }
        public string Key { get; }
        public string PlatformName { get; }
    }
}