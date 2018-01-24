using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Common.Solution._legacy;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface ISolutionProjectReferencesFactory
    {
        SolutionProjectReferences Create(string solutionFilePath);
    }
}
