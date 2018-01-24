﻿using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers
{
    public interface IStringToGlobalExtensibilitiesAdapter
    {
        GlobalExtensibilities Adapt(List<string> solutionDataLines);
    }
}