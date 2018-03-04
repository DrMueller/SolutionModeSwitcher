using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectBuild;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectBuild
{
    public interface IProjectBuildConfigurationAdapter
    {
        IReadOnlyCollection<ProjectBuildConfiguration> Adapt(XDocument document);
    }
}