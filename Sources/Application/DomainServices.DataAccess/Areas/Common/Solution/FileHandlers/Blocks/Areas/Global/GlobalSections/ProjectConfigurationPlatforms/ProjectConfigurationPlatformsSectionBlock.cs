using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ProjectConfigurationPlatforms
{
    public class ProjectConfigurationPlatformsSectionBlock : GlobalSectionBlock
    {
        public ProjectConfigurationPlatformsSectionBlock(string startData, string endData, List<ProjectConfigurationBlock> configurationBlocks)
            : base(startData, endData, configurationBlocks)
        {
            Guard.ObjectNotNull(() => configurationBlocks);
            ConfigurationBlocks = configurationBlocks;
        }

        public List<ProjectConfigurationBlock> ConfigurationBlocks { get; }
    }
}