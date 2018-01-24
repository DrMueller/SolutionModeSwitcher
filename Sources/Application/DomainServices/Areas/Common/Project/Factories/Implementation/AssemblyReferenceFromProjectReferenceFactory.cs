using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.Implementation
{
    public class AssemblyReferenceFromProjectReferenceFactory : IAssemblyReferenceFromProjectReferenceFactory
    {
        private readonly IAssemblyReferenceMetaDataFactory _assemblyReferenceMetaDataFactory;
        private readonly IProjectConfigurationFileRepository _projectConfigurationFileRepository;

        public AssemblyReferenceFromProjectReferenceFactory(
            IAssemblyReferenceMetaDataFactory assemblyReferenceMetaDataFactory,
            IProjectConfigurationFileRepository projectConfigurationFileRepository)
        {
            _assemblyReferenceMetaDataFactory = assemblyReferenceMetaDataFactory;
            _projectConfigurationFileRepository = projectConfigurationFileRepository;
        }

        public ProjectAssemblyReference CreateFromProjectReferenceFilePath(string projectReferenceFilePath, string relativeIncludePath)
        {
            return null;

            //var projectConfig = _projectConfigurationFileRepository.Load(projectReferenceFilePath);

            //var includeDefinition = _assemblyReferenceMetaDataFactory.CreateIncludeDefinition(projectConfig.PropertiesConfiguration.AssemblyName);
            //var hintPath = _assemblyReferenceMetaDataFactory.CreateHintPath(relativeIncludePath, projectConfig);

            //var result = new ProjectAssemblyReference(includeDefinition, hintPath, null, false);
            //return result;
        }
    }
}