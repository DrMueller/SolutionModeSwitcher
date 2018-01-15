using System.Collections.Generic;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface ISolutionProjectBlockFactory
    {
        SolutionProjectBlock FindBlock(string assemblyName);

        IReadOnlyCollection<SolutionProjectBlock> GetAllBlocks();

        void Initialize(string solutionPath);
    }
}