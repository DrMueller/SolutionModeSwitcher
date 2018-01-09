using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories.SubFactories;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.Implementation
{
    public class AssemblyReferenceFromProjectReferenceFactory : IAssemblyReferenceFromProjectReferenceFactory
    {
        private readonly IAssemblyReferenceMetaDataFactory _assemblyReferenceMetaDataFactory;
        private readonly IProjectConfigurationFileFactory _projectFileConfigurationFactory;

        public AssemblyReferenceFromProjectReferenceFactory(
            IAssemblyReferenceMetaDataFactory assemblyReferenceMetaDataFactory,
            IProjectConfigurationFileFactory projectFileConfigurationFactory)
        {
            _assemblyReferenceMetaDataFactory = assemblyReferenceMetaDataFactory;
            _projectFileConfigurationFactory = projectFileConfigurationFactory;
        }

        public ProjectAssemblyReference CreateFromProjectReferenceFilePath(string projectReferenceFilePath, string relativeIncludePath)
        {
            var projectConfig = _projectFileConfigurationFactory.Create(projectReferenceFilePath);

            var includeDefinition = _assemblyReferenceMetaDataFactory.CreateIncludeDefinition(projectConfig.PropertiesConfiguration.AssemblyName);
            var hintPath = _assemblyReferenceMetaDataFactory.CreateHintPath(relativeIncludePath, projectConfig);

            var result = new ProjectAssemblyReference(includeDefinition, hintPath, null, false);
            return result;
        }
    }
}