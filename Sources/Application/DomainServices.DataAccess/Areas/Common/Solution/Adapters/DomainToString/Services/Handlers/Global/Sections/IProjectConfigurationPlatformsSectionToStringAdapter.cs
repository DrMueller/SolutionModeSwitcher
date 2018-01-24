﻿using System.Collections.Generic;
using System.Text;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.Global.Sections
{
    public interface IProjectConfigurationPlatformsSectionToStringAdapter
    {
        void Adapt(IEnumerable<SolutionProject> solutionProjects, IExtendedStringBuilder sb);
    }
}