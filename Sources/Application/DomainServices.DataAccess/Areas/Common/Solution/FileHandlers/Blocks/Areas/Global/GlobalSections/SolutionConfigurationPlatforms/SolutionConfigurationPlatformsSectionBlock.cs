using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionConfigurationPlatforms
{
    public class SolutionConfigurationPlatformsSectionBlock : GlobalSectionBlock
    {
        public SolutionConfigurationPlatformsSectionBlock(string startData, string endData, List<ConfigurationEntryBlock> configurations)
            : base(startData, endData, configurations)
        {
            Guard.ObjectNotNull(() => configurations);

            Configurations = configurations;
        }

        public List<ConfigurationEntryBlock> Configurations { get; }
    }
}