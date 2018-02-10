using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class TargetConfiguration
    {
        public TargetConfiguration(
            Maybe<AspNetCompilerConfiguration> aspNetCompilerConfiguration,
            Maybe<TransformXmlConfiguration> transformXmlConfiguration,
            Maybe<DeploymentConfiguration> deploymentConfiguration,
            Maybe<EnsurePostSharpImportedConfiguration> ensurePostSharpImportedConfiguration,
            Maybe<ProjectBuildConfiguration> projectBuildConfiguration)
        {
            AspNetCompilerConfiguration = aspNetCompilerConfiguration;
            TransformXmlConfiguration = transformXmlConfiguration;
            DeploymentConfiguration = deploymentConfiguration;
            EnsurePostSharpImportedConfiguration = ensurePostSharpImportedConfiguration;
            ProjectBuildConfiguration = projectBuildConfiguration;
        }

        public Maybe<AspNetCompilerConfiguration> AspNetCompilerConfiguration { get; }
        public Maybe<DeploymentConfiguration> DeploymentConfiguration { get; }
        public Maybe<EnsurePostSharpImportedConfiguration> EnsurePostSharpImportedConfiguration { get; }
        public Maybe<ProjectBuildConfiguration> ProjectBuildConfiguration { get; }
        public Maybe<TransformXmlConfiguration> TransformXmlConfiguration { get; }
    }
}