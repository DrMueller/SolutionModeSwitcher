using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories
{
    public interface IXmlProjectAssemblyReferenceFactory
    {
        XElement CreateElement(ProjectAssemblyReference assemblyReference);
    }
}