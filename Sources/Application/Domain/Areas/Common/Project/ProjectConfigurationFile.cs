using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectConfigurations;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectExtensions;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;
using Mmu.Sms.Domain.Areas.Common.Project.Tasks;
using Mmu.Sms.Domain.Areas.Common.Project.VisualStudio;

namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectConfigurationFile
    {
        public ProjectConfigurationFile(
            string filePath,
            ProjectConfiguration projectConfiguration,
            IReadOnlyCollection<ImportEntry> importEntries,
            ProjectPropertiesConfiguration projectPropertiesConfiguration,
            Maybe<PostSharpConfiguration> postSharpConfiguration,
            IReadOnlyCollection<ProjectBuildConfiguration> buildConfigurations,
            IReadOnlyCollection<ProjectAssemblyReference> assemblyReferences,
            IReadOnlyCollection<InclusionEntry> inclusionEntries,
            IReadOnlyCollection<ProjectReference> projectReferences,
            VisualStudioConfiguration visualStudioConfiguration,
            Maybe<SlowCheetahConfiguration> slowCheetaConfiguration,
            IReadOnlyCollection<Target> targets,
            Maybe<VisualStudioExtensionsConfiguration> visualStudioExtensionsConfiguration,
            IReadOnlyCollection<UsingTask> usingTasks)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            Guard.ObjectNotNull(() => importEntries);
            Guard.ObjectNotNull(() => projectPropertiesConfiguration);
            Guard.ObjectNotNull(() => buildConfigurations);
            Guard.ObjectNotNull(() => assemblyReferences);
            Guard.ObjectNotNull(() => inclusionEntries);
            Guard.ObjectNotNull(() => projectReferences);
            Guard.ObjectNotNull(() => visualStudioConfiguration);
            Guard.ObjectNotNull(() => targets);
            Guard.ObjectNotNull(() => usingTasks);

            FilePath = filePath;
            ProjectConfiguration = projectConfiguration;
            ImportEntries = importEntries;
            ProjectPropertiesConfiguration = projectPropertiesConfiguration;
            PostSharpConfiguration = postSharpConfiguration;
            BuildConfigurations = buildConfigurations;
            AssemblyReferences = assemblyReferences;
            InclusionEntries = inclusionEntries;
            ProjectReferences = projectReferences;
            VisualStudioConfiguration = visualStudioConfiguration;
            SlowCheetaConfiguration = slowCheetaConfiguration;
            Targets = targets;
            VisualStudioExtensionsConfiguration = visualStudioExtensionsConfiguration;
            UsingTasks = usingTasks;
        }

        public IReadOnlyCollection<ProjectAssemblyReference> AssemblyReferences { get; }
        public IReadOnlyCollection<ProjectBuildConfiguration> BuildConfigurations { get; }
        public string FilePath { get; }
        public IReadOnlyCollection<ImportEntry> ImportEntries { get; }
        public IReadOnlyCollection<InclusionEntry> InclusionEntries { get; }
        public Maybe<PostSharpConfiguration> PostSharpConfiguration { get; }
        public ProjectConfiguration ProjectConfiguration { get; }
        public ProjectPropertiesConfiguration ProjectPropertiesConfiguration { get; }
        public IReadOnlyCollection<ProjectReference> ProjectReferences { get; }
        public Maybe<SlowCheetahConfiguration> SlowCheetaConfiguration { get; }
        public IReadOnlyCollection<Target> Targets { get; }
        public IReadOnlyCollection<UsingTask> UsingTasks { get; }
        public VisualStudioConfiguration VisualStudioConfiguration { get; }
        public Maybe<VisualStudioExtensionsConfiguration> VisualStudioExtensionsConfiguration { get; }
    }
}