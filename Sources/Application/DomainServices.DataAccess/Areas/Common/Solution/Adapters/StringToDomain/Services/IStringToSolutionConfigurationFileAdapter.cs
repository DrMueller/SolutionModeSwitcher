using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services
{
    public interface IStringToSolutionConfigurationFileAdapter
    {
        SolutionConfigurationFile Adapt(string filePath);
    }
}