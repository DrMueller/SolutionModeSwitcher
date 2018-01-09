using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Factories
{
    public interface ISolutionConfigurationFileFactory
    {
        SolutionConfigurationFile Create(string filePath);
    }
}