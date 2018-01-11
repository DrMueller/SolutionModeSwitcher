﻿using Mmu.Sms.Domain.Areas.ModeSwitching;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories
{
    public interface ISolutionModeShadowCopyRepository
    {
        SolutionModeShadowCopy Load(string configurationName);

        void Save(SolutionModeShadowCopy shadowCopy);
    }
}