﻿using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions
{
    public interface ICopyToOutputDirectoryTypeAdapter
    {
        CopyToOutputDirectoryType Adapt(XElement element);
    }
}