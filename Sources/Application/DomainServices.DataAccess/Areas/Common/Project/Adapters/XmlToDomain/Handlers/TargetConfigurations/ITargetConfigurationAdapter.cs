using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.TargetConfigurations
{
    public interface ITargetConfigurationAdapter
    {
        TargetConfiguration Adapt(XDocument document);
    }
}