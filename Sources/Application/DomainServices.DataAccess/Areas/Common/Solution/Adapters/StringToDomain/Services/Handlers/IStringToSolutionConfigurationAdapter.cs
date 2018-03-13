using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers
{
    public interface IStringToSolutionConfigurationAdapter
    {
        ICollection<SolutionConfiguration> Adapt(string filePath);
    }
}