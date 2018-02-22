using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class TargetConfiguration
    {
        public TargetConfiguration(
            Maybe<AspNetCompilerConfiguration> aspNetCompilerConfiguration,
            Maybe<DeploymentConfiguration> deploymentConfiguration,
            Maybe<EnsurePostSharpImportedConfiguration> ensurePostSharpImportedConfiguration,
            Maybe<TransformXmlConfiguration> transformXmlConfiguration,
            Maybe<EnsureNuGetPackageBuildImportsConfiguration> ensureNuGetPackageBuildImportsConfiguration)
        {
            AspNetCompilerConfiguration = aspNetCompilerConfiguration;
            TransformXmlConfiguration = transformXmlConfiguration;
            DeploymentConfiguration = deploymentConfiguration;
            EnsurePostSharpImportedConfiguration = ensurePostSharpImportedConfiguration;
            EnsureNuGetPackageBuildImportsConfiguration = ensureNuGetPackageBuildImportsConfiguration;
        }

        public Maybe<AspNetCompilerConfiguration> AspNetCompilerConfiguration { get; }
        public Maybe<DeploymentConfiguration> DeploymentConfiguration { get; }
        public Maybe<EnsureNuGetPackageBuildImportsConfiguration> EnsureNuGetPackageBuildImportsConfiguration { get; }
        public Maybe<EnsurePostSharpImportedConfiguration> EnsurePostSharpImportedConfiguration { get; }
        public Maybe<TransformXmlConfiguration> TransformXmlConfiguration { get; }
    }
}