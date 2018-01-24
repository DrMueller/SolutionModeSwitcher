using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionConfiguration
    {
        public SolutionConfiguration(string configurationName, string fullName, string platformName)
        {
            Guard.StringNotNullOrEmpty(() => configurationName);
            Guard.StringNotNullOrEmpty(() => fullName);
            Guard.StringNotNullOrEmpty(() => platformName);

            ConfigurationName = configurationName;
            FullName = fullName;
            PlatformName = platformName;
        }

        public string ConfigurationName { get; }
        public string FullName { get; }
        public string PlatformName { get; }
    }
}