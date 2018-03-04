using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Inclusions
{
    public interface IInclusionEntryToXmlAdapter
    {
        XElement Adapt(ProjectConfigurationFile projectConfigFile, BuildAction buildAction);
    }
}