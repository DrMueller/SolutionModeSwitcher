using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ExtensibilityGlobals
{
    public class ExtensibilityGlobalsSectionBlock : GlobalSectionBlock
    {
        private readonly string _endData;
        private readonly string _startData;

        public ExtensibilityGlobalsSectionBlock(string startData, string endData, SolutionGuidBlock solutionGuidBlock)
           : base(startData, endData, new List<BlockElement> { solutionGuidBlock })
        {
            _startData = startData;
            _endData = endData;
            Guard.ObjectNotNull(() => solutionGuidBlock);

            SolutionGuidBlock = solutionGuidBlock;
        }

        public SolutionGuidBlock SolutionGuidBlock { get; }

        public override string CreateOutput()
        {
            var result = _startData;
            result += SolutionGuidBlock.CreateOutput();
            result += _endData;

            return result;
        }
    }
}