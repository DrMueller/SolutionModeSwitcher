using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionProperties
{
    public class SolutionPropertiesSectionBlock : GlobalSectionBlock
    {
        public HideSolutionNodeBlock HideSolutionNodeBlock { get; }

        public SolutionPropertiesSectionBlock(string startData, string endData, HideSolutionNodeBlock hideSolutionNodeBlock)
        {
            HideSolutionNodeBlock = hideSolutionNodeBlock;
        }

    }
}
