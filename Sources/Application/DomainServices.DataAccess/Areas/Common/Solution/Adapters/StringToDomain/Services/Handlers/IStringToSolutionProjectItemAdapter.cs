using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers
{
    public interface IStringToSolutionProjectItemAdapter
    {
        IReadOnlyCollection<SolutionProjectItem> Adapt(string projectGuid, List<string> solutionDataLines);
    }
}