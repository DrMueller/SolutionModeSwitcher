using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences
{
    public class IncludeDefinition
    {
        public IncludeDefinition(string shortName, string version, string culture, string publicKeyToken, string processorArchitecture)
        {
            Guard.StringNotNullOrEmpty(() => shortName);

            ShortName = shortName;
            Version = version;
            Culture = culture;
            PublicKeyToken = publicKeyToken;
            ProcessorArchitecture = processorArchitecture;
        }

        public string Culture { get; }
        public string ProcessorArchitecture { get; }
        public string PublicKeyToken { get; }
        public string ShortName { get; }
        public string Version { get; }
    }
}