using System.Collections.Generic;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface ISolutionFileBlockFactory
    {
        SolutionProjectBlock FindProjectBlock(string assemblyName);

        IReadOnlyCollection<SolutionProjectBlock> CreateAllProjectBlocks();

        void Initialize(string solutionPath);

        IReadOnlyCollection<GlobalSectionBlock> CreateAllGlobalSectionBlocks();
        
        
    }
}