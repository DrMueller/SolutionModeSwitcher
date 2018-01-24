using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Repositories
{
    public class ProjectConfigurationFileRepository : IProjectConfigurationFileRepository
    {
        private readonly IXmlToProjectConfigurationFileAdapter _xmlToProjectConfigFileAdapter;

        public ProjectConfigurationFileRepository(
            IXmlToProjectConfigurationFileAdapter xmlToProjectConfigFileAdapter)
        {
            _xmlToProjectConfigFileAdapter = xmlToProjectConfigFileAdapter;
        }

        public ProjectConfigurationFile Load(string filePath)
        {
            var result = _xmlToProjectConfigFileAdapter.Adapt(filePath);
            return result;
        }

        public void Save(ProjectConfigurationFile projectConfigurationFile)
        {
            //var xmlDocument = _projectConfigurationDocumentFactory.CreateDocument(projectConfigurationFile);
            //xmlDocument.Save(projectConfigurationFile.FilePath);
        }
    }
}