using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories.SubFactories;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.Implementation
{
    public class ProjectConfigurationFileFactory : IProjectConfigurationFileFactory
    {
        private readonly IProjectAssemblyReferenceFactory _assemblyReferenceFactory;
        private readonly IProjectBuildConfigurationFactory _buildConfigurationFactory;
        private readonly IProjectReferenceFactory _projectReferenceFactory;
        private readonly IProjectPropertiesConfigurationFactory _propertiesConfigurationFactory;

        public ProjectConfigurationFileFactory(
            IProjectReferenceFactory projectReferenceFactory,
            IProjectAssemblyReferenceFactory assemblyReferenceFactory,
            IProjectBuildConfigurationFactory buildConfigurationFactory,
            IProjectPropertiesConfigurationFactory propertiesConfigurationFactory)
        {
            _projectReferenceFactory = projectReferenceFactory;
            _assemblyReferenceFactory = assemblyReferenceFactory;
            _buildConfigurationFactory = buildConfigurationFactory;
            _propertiesConfigurationFactory = propertiesConfigurationFactory;
        }

        public ProjectConfigurationFile Create(string filePath)
        {
            var configDocument = XDocument.Load(filePath);
            var projectReferences = _projectReferenceFactory.CreateFromDocument(configDocument);
            var assemblyReferences = _assemblyReferenceFactory.CreateFromDocument(configDocument);
            var buildConfigurations = _buildConfigurationFactory.CreateFromDocument(configDocument);
            var propertiesConfiguration = _propertiesConfigurationFactory.CreateFromDocument(configDocument);

            var result = new ProjectConfigurationFile(
                filePath,
                assemblyReferences,
                projectReferences,
                propertiesConfiguration,
                buildConfigurations);

            return result;
        }
    }
}