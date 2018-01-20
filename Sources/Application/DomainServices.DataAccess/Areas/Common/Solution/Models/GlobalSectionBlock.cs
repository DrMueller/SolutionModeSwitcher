using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models
{
    public class GlobalSectionBlock
    {
        public GlobalSectionBlock(IReadOnlyCollection<SectionEntryBlock> blocks)
        {
            Guard.ObjectNotNull(() => blocks);
            Blocks = blocks;
        }

        public IReadOnlyCollection<SectionEntryBlock> Blocks { get; }
    }
}