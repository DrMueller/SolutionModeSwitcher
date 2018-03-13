using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories
{
    public interface ISolutionConfigurationFileRepository
    {
        SolutionConfigurationFile Load(string filePath);

        void Save(SolutionConfigurationFile solutionConfigFile);
    }
}