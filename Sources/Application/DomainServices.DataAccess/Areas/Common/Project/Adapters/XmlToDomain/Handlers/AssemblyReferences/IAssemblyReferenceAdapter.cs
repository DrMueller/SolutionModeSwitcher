using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.AssemblyReferences
{
    public interface IAssemblyReferenceAdapter
    {
        IReadOnlyCollection<ProjectAssemblyReference> Adapt(XDocument document);
    }
}