using System.Text;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ExtensibilityGlobals;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.NestedProjects;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ProjectConfigurationPlatforms;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionConfigurationPlatforms;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionProperties;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global
{
    public class GlobalBlock : BlockElement
    {
        public GlobalBlock(
            ExtensibilityGlobalsSectionBlock extensisibilityGlobalsSectionBlock,
            NestedProjectsSectionBlock nestedProjectsSectionBlock,
            ProjectConfigurationPlatformsSectionBlock projectConfigPlatformsSectionBlock,
            SolutionConfigurationPlatformsSectionBlock solutionConfigPlatformsSectionBlock,
            SolutionPropertiesSectionBlock solutionPropertiesSectionBlock)
        {
            Guard.ObjectNotNull(() => extensisibilityGlobalsSectionBlock);
            Guard.ObjectNotNull(() => nestedProjectsSectionBlock);
            Guard.ObjectNotNull(() => projectConfigPlatformsSectionBlock);
            Guard.ObjectNotNull(() => solutionConfigPlatformsSectionBlock);
            Guard.ObjectNotNull(() => solutionPropertiesSectionBlock);

            ExtensisibilityGlobalsSectionBlock = extensisibilityGlobalsSectionBlock;
            NestedProjectsSectionBlock = nestedProjectsSectionBlock;
            ProjectConfigPlatformsSectionBlock = projectConfigPlatformsSectionBlock;
            SolutionConfigPlatformsSectionBlock = solutionConfigPlatformsSectionBlock;
            SolutionPropertiesSectionBlock = solutionPropertiesSectionBlock;
        }

        public ExtensibilityGlobalsSectionBlock ExtensisibilityGlobalsSectionBlock { get; }
        public NestedProjectsSectionBlock NestedProjectsSectionBlock { get; }
        public ProjectConfigurationPlatformsSectionBlock ProjectConfigPlatformsSectionBlock { get; }
        public SolutionConfigurationPlatformsSectionBlock SolutionConfigPlatformsSectionBlock { get; }
        public SolutionPropertiesSectionBlock SolutionPropertiesSectionBlock { get; }

        public override string CreateOutput()
        {
            var sb = new StringBuilder();
            sb.Append(SolutionConfigPlatformsSectionBlock.CreateOutput());
            sb.Append(ProjectConfigPlatformsSectionBlock.CreateOutput());
            sb.Append(SolutionPropertiesSectionBlock.CreateOutput());
            sb.Append(NestedProjectsSectionBlock.CreateOutput());
            sb.Append(ExtensisibilityGlobalsSectionBlock.CreateOutput());

            var result = sb.ToString();
            return result;
        }
    }

}