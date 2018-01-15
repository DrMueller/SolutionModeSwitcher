using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Repositories
{
    public interface IProjectConfigurationFileRepository
    {
        ProjectConfigurationFile Load(string filePath);

        void Save(ProjectConfigurationFile projectConfigurationFile);
    }
}