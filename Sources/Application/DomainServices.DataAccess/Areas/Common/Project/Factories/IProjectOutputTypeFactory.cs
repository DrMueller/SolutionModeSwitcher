using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories
{
    public interface IProjectOutputTypeFactory
    {
        ProjectOutputType CreateFromDescription(string description);
    }
}