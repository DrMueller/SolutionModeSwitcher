using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy
{
    public interface IProjectAssemblyReferenceFactory
    {
        IList<ProjectAssemblyReference> CreateFromDocument(XDocument configDocument);
    }
}