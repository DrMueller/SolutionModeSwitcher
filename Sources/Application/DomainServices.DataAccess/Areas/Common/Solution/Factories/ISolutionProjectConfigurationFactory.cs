using System.Collections.Generic;
using Microsoft.Build.Construction;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories
{
    public interface ISolutionProjectConfigurationFactory
    {
        IReadOnlyCollection<SolutionProjectConfiguration> Create(ProjectInSolution project);
    }
}