using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.Application.Areas.Domain.Common.Solution.Factories
{
    public interface ISolutionConfigurationDataFactory
    {
        string CreateSolutionConfigurationData(SolutionConfigurationFile solutionConfigFile);
    }
}