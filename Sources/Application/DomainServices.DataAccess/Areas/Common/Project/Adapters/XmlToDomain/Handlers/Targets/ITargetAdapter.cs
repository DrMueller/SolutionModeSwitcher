using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets
{
    public interface ITargetAdapter
    {
        IReadOnlyCollection<Target> Adapt(XDocument document);
    }
}