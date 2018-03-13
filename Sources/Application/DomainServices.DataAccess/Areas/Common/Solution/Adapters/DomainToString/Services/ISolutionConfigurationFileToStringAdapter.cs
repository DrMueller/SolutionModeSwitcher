using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services
{
    public interface ISolutionConfigurationFileToStringAdapter
    {
        string Adapt(SolutionConfigurationFile solutionConfigile);
    }
}