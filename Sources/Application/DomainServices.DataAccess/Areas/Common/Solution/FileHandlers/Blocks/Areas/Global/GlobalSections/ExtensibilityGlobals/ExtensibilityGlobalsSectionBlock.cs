using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ExtensibilityGlobals
{
    public class ExtensibilityGlobalsSectionBlock : GlobalSectionBlock
    {
        public ExtensibilityGlobalsSectionBlock(string startData, string endData, SolutionGuidBlock solutionGuidBlock)
           : base(startData, endData, new List<BlockElement> { solutionGuidBlock })
        {
            Guard.ObjectNotNull(() => solutionGuidBlock);

            SolutionGuidBlock = solutionGuidBlock;
        }

        public SolutionGuidBlock SolutionGuidBlock { get; }
    }
}