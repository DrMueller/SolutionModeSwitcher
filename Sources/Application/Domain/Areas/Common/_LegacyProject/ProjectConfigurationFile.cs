//using System.Collections.Generic;
//using System.Linq;
//using Mmu.Sms.Common.LanguageExtensions.Invariance;
//using Mmu.Sms.Domain.Areas.Common.Project;
//using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;

//namespace Mmu.Sms.Domain.Areas.Common._LegacyProject
//{
//    public class ProjectConfigurationFile
//    {
//        private readonly IList<ProjectAssemblyReference> _assemblyReferences;
//        private readonly List<ProjectReference> _projectReferences;

//        public ProjectConfigurationFile(
//            string filePath,
//            IList<ProjectAssemblyReference> assemblyReferences,
//            List<ProjectReference> projectReferences,
//            ProjectPropertiesConfiguration propertiesConfiguration,
//            IReadOnlyCollection<ProjectBuildConfiguration> buildConfigurations)
//        {
//            Guard.StringNotNullOrEmpty(() => filePath);
//            Guard.ObjectNotNull(() => assemblyReferences);
//            Guard.ObjectNotNull(() => projectReferences);
//            Guard.ObjectNotNull(() => propertiesConfiguration);
//            Guard.ObjectNotNull(() => buildConfigurations);

//            FilePath = filePath;
//            PropertiesConfiguration = propertiesConfiguration;
//            BuildConfigurations = buildConfigurations;
//            _assemblyReferences = assemblyReferences;
//            _projectReferences = projectReferences;
//        }

//        public IReadOnlyCollection<ProjectAssemblyReference> AssemblyReferences => _assemblyReferences.ToList();
//        public IReadOnlyCollection<ProjectBuildConfiguration> BuildConfigurations { get; }
//        public string FilePath { get; }
//        public IReadOnlyCollection<ProjectReference> ProjectReferences => _projectReferences;
//        public ProjectPropertiesConfiguration PropertiesConfiguration { get; }

//        public void SubstituteProjectReference(ProjectReference projectReference, ProjectAssemblyReference assemblyReference)
//        {
//            _projectReferences.Remove(projectReference);
//            _assemblyReferences.Add(assemblyReference);
//        }
//    }
//}