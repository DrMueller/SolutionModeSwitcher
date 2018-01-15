using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Repositories
{
    public class ProjectConfigurationFileRepository : IProjectConfigurationFileRepository
    {
        private readonly IProjectAssemblyReferenceFactory _projectAssemblyReferenceFactory;
        private readonly IProjectBuildConfigurationFactory _projectBuildConfigurationFactory;
        private readonly IProjectConfigurationDocumentFactory _projectConfigurationDocumentFactory;
        private readonly IProjectPropertiesConfigurationFactory _projectPropertiesConfigurationFactory;
        private readonly IProjectReferenceFactory _projectReferenceFactory;

        public ProjectConfigurationFileRepository(
            IProjectConfigurationDocumentFactory projectConfigurationDocumentFactory,
            IProjectBuildConfigurationFactory projectBuildConfigurationFactory,
            IProjectAssemblyReferenceFactory projectAssemblyReferenceFactory,
            IProjectPropertiesConfigurationFactory projectPropertiesConfigurationFactory,
            IProjectReferenceFactory projectReferenceFactory)
        {
            _projectConfigurationDocumentFactory = projectConfigurationDocumentFactory;
            _projectBuildConfigurationFactory = projectBuildConfigurationFactory;
            _projectAssemblyReferenceFactory = projectAssemblyReferenceFactory;
            _projectPropertiesConfigurationFactory = projectPropertiesConfigurationFactory;
            _projectReferenceFactory = projectReferenceFactory;
        }

        public ProjectConfigurationFile Load(string filePath)
        {
            var document = XDocument.Load(filePath);
            var buildConfigurations = _projectBuildConfigurationFactory.CreateFromDocument(document);
            var propertiesConfigurations = _projectPropertiesConfigurationFactory.CreateFromDocument(document);
            var assemblyReferences = _projectAssemblyReferenceFactory.CreateFromDocument(document);
            var projectReferences = _projectReferenceFactory.CreateFromDocument(document);

            var result = new ProjectConfigurationFile(filePath, assemblyReferences, projectReferences, propertiesConfigurations, buildConfigurations);
            return result;
        }

        public void Save(ProjectConfigurationFile projectConfigurationFile)
        {
            var xmlDocument = _projectConfigurationDocumentFactory.CreateDocument(projectConfigurationFile);
            xmlDocument.Save(projectConfigurationFile.FilePath);
        }
    }
}