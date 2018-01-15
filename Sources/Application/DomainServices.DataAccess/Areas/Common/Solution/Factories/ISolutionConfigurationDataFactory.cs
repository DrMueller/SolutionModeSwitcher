using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface ISolutionConfigurationDataFactory
    {
        string CreateSolutionConfigurationData(SolutionConfigurationFile solutionConfigFile);
    }
}