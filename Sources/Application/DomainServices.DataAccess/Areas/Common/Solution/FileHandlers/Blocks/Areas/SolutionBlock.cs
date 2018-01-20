using System.Collections.Generic;
using System.Text;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Heading;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Projects;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas
{
    public class SolutionBlock : BlockElement
    {
        public SolutionBlock(
            HeadingBlock headingBlock,
            List<ProjectBlock> projectBlocks,
            GlobalBlock globalBlock)
        {
            Guard.ObjectNotNull(() => headingBlock);
            Guard.ObjectNotNull(() => projectBlocks);
            Guard.ObjectNotNull(() => globalBlock);

            HeadingBlock = headingBlock;
            ProjectBlocks = projectBlocks;
            GlobalBlock = globalBlock;
        }

        public GlobalBlock GlobalBlock { get; }
        public HeadingBlock HeadingBlock { get; }
        public List<ProjectBlock> ProjectBlocks { get; }

        public override string CreateOutput()
        {
            var sb = new StringBuilder();
            sb.Append(HeadingBlock.CreateOutput());

            foreach (var projectBlock in ProjectBlocks)
            {
                sb.Append(projectBlock.CreateOutput());
            }

            sb.Append(GlobalBlock.CreateOutput());

            var result = sb.ToString();
            return result;
        }
    }
}