using System.Collections.Generic;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Models;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Handlers
{
    public interface ISolutionProjectBlockHandler
    {
        SolutionProjectBlock FindBlock(string assemblyName);

        IReadOnlyCollection<SolutionProjectBlock> GetAllBlocks();

        void Initialize(string solutionPath);
    }
}