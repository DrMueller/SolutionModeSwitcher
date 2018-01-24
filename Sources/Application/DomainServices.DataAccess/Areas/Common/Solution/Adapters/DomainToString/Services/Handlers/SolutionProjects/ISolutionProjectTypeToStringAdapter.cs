using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects
{
    public interface ISolutionProjectTypeToStringAdapter
    {
        string AdaptToGuid(SolutionProjectType solutionProjectType);
    }
}