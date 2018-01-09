using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.Application.Areas.Domain.Common.Project.Factories.SubFactories
{
    public interface IXmlProjectAssemblyReferenceFactory
    {
        XElement CreateElement(ProjectAssemblyReference assemblyReference);
    }
}