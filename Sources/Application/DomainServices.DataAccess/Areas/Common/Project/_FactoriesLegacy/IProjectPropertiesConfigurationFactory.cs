using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy
{
    public interface IProjectPropertiesConfigurationFactory
    {
        ProjectPropertiesConfiguration CreateFromDocument(XDocument document);
    }
}