using System.Collections.Generic;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionProperties
{
    public class SolutionPropertiesSectionBlock : GlobalSectionBlock
    {
        public SolutionPropertiesSectionBlock(string startData, string endData, HideSolutionNodeBlock hideSolutionNodeBlock)
            : base(startData, endData, new List<BlockElement> { hideSolutionNodeBlock })
        {
            HideSolutionNodeBlock = hideSolutionNodeBlock;
        }

        public HideSolutionNodeBlock HideSolutionNodeBlock { get; }
    }
}