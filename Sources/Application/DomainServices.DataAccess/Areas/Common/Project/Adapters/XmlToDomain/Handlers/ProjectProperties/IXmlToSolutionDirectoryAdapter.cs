using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties
{
    public interface IXmlToSolutionDirectoryAdapter
    {
        Maybe<SolutionDirectory> Adapt(XElement element);
    }
}