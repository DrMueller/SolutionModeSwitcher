using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories
{
    public interface IProjectAssemblyReferenceFactory
    {
        IList<ProjectAssemblyReference> CreateFromDocument(XDocument configDocument);
    }
}