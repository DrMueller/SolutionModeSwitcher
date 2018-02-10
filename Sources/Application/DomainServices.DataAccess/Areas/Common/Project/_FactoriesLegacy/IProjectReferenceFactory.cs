using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy
{
    public interface IProjectReferenceFactory
    {
        List<ProjectReference> CreateFromDocument(XDocument configDocument);
    }
}