using System.Collections.Generic;
using System.Text;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.NestedProjects
{
    public class NestedProjectsSectionBlock : GlobalSectionBlock
    {
        public NestedProjectsSectionBlock(string startData, string endData, List<HierarchyEntryBlock> hierarchyEntryBlocks)
            : base(startData, endData, hierarchyEntryBlocks)
        {
            HierarchyEntryBlocks = hierarchyEntryBlocks;
        }

        public List<HierarchyEntryBlock> HierarchyEntryBlocks { get; }
    }
}