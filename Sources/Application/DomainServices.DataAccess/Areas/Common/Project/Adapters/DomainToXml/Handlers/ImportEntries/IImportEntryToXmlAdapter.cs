﻿using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ImportEntries
{
    public interface IImportEntryToXmlAdapter
    {
        IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile);
    }
}