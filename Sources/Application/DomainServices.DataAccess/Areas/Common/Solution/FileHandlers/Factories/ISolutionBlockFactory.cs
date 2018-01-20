using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Factories
{
    public interface ISolutionBlockFactory
    {
        SolutionBlock Parse(string solutionFilePath);

    }
}
