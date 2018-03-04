using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Repositories
{
    public class ProjectConfigurationFileRepository : IProjectConfigurationFileRepository
    {
        private readonly IProjectConfigurationFileToXmlAdapter _projectToXmlConfigFileAdapter;
        private readonly IXmlToProjectConfigurationFileAdapter _xmlToProjectConfigFileAdapter;

        public ProjectConfigurationFileRepository(
            IXmlToProjectConfigurationFileAdapter xmlToProjectConfigFileAdapter,
            IProjectConfigurationFileToXmlAdapter projectToXmlConfigFileAdapter
        )
        {
            _xmlToProjectConfigFileAdapter = xmlToProjectConfigFileAdapter;
            _projectToXmlConfigFileAdapter = projectToXmlConfigFileAdapter;
        }

        public ProjectConfigurationFile Load(string filePath)
        {
            var result = _xmlToProjectConfigFileAdapter.Adapt(filePath);
            return result;
        }

        public void Save(ProjectConfigurationFile projectConfigFile)
        {
            var xmlDocument = _projectToXmlConfigFileAdapter.Adapt(projectConfigFile);
            xmlDocument.Save(projectConfigFile.FilePath);
        }
    }
}