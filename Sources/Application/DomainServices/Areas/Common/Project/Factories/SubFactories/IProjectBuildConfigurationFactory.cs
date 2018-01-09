using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.SubFactories
{
    public interface IProjectBuildConfigurationFactory
    {
        IReadOnlyCollection<ProjectBuildConfiguration> CreateFromDocument(XDocument document);
    }
}