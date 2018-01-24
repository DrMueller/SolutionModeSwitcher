using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectConfiguration
    {
        public SolutionProjectConfiguration(
            string configurationKey,
            string configurationDescrption)
        {
            // {D81E9F78-5F08-444F-ABAA-49B3FEF20E59}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
            // Debug|Any CPU = Key
            // ActiveCfg = Debug|Any CPU = Description
            Guard.StringNotNullOrEmpty(() => configurationKey);
            Guard.StringNotNullOrEmpty(() => configurationDescrption);

            ConfigurationKey = configurationKey;
            ConfigurationDescrption = configurationDescrption;
        }

        public string ConfigurationKey { get; }
        public string ConfigurationDescrption { get; }
    }
}