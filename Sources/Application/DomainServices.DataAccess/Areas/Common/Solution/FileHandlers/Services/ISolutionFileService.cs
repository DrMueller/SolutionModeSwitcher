﻿using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Services
{
    public interface ISolutionFileService
    {
        string RearrangeSolutionFile(SolutionConfigurationFile solutionConfigFile);
    }
}