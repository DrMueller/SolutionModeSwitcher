using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories.Handlers
{
    public interface ISolutionProjectReferencesRepository
    {
        SolutionProjectReferences Load(string solutionFilePath);
    }
}
