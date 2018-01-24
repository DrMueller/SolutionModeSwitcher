using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common._LegacyProject
{
    public class ProjectPropertiesConfiguration
    {
        public ProjectPropertiesConfiguration(
            string rootNamespace,
            string assemblyName,
            ProjectOutputType outputType
        )
        {
            Guard.StringNotNullOrEmpty(() => rootNamespace);
            Guard.StringNotNullOrEmpty(() => assemblyName);
            Guard.ObjectNotNull(() => outputType);

            RootNamespace = rootNamespace;
            AssemblyName = assemblyName;
            OutputType = outputType;
        }

        public string AssemblyName { get; }
        public ProjectOutputType OutputType { get; }
        public string RootNamespace { get; }

        public string AssemblyFileName
        {
            get
            {
                var result = string.Concat(AssemblyName, OutputType.FileExtension);
                return result;
            }
        }
    }
}