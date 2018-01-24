using System.Text;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common._LegacyProject
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

        public string CreateOutput()
        {
            var sb = new StringBuilder();
            sb.Append(ShortName);
            CheckAddPart(sb, "Version", Version);
            CheckAddPart(sb, "Culture", Culture);
            CheckAddPart(sb, "PublicKeyToken", PublicKeyToken);
            CheckAddPart(sb, "processorArchitecture", ProcessorArchitecture);

            var result = sb.ToString();
            return result;
        }

        private static void CheckAddPart(StringBuilder sb, string partName, string part)
        {
            if (string.IsNullOrEmpty(part))
            {
                return;
            }

            sb.Append(", ");
            sb.Append(partName);
            sb.Append("=");
            sb.Append(part);
        }
    }
}