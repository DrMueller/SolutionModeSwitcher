﻿using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services
{
    public interface ISolutionModeRevertingService
    {
        SolutionSwitchResult RevertSolutionMode(SolutionModeConfiguration configuration);
    }
}