using System.Collections.Generic;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface IGlobalSectionBlockFactory
    {
        IReadOnlyCollection<GlobalSectionBlock> CreateGlobalSectionBlocks(string solutionConfigurationData);
    }
}