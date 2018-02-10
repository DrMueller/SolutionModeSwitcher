﻿using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories
{
    public interface IProjectOutputTypeFactory
    {
        ProjectOutputType CreateFromDescription(string description);
    }
}