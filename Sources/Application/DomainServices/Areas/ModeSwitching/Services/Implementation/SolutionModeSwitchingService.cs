using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Handlers;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeSwitchingService : ISolutionModeSwitchingService
    {
        private readonly IAssemblyReferenceFromProjectReferenceFactory _assemblyReferenceFactory;
        private readonly IProjectConfigurationFileFactory _projectConfigurationFileFactory;
        private readonly ISolutionModeShadowCopyHandler _shadowCopyHandler;
        private readonly ISolutionConfigurationFileFactory _solutionConfigurationFileFactory;

        public SolutionModeSwitchingService(
            IProjectConfigurationFileFactory projectConfigurationFileFactory,
            IAssemblyReferenceFromProjectReferenceFactory assemblyReferenceFactory,
            ISolutionConfigurationFileFactory solutionConfigurationFileFactory,
            ISolutionModeShadowCopyHandler shadowCopyHandler)
        {
            _projectConfigurationFileFactory = projectConfigurationFileFactory;
            _assemblyReferenceFactory = assemblyReferenceFactory;
            _solutionConfigurationFileFactory = solutionConfigurationFileFactory;
            _shadowCopyHandler = shadowCopyHandler;
        }

        public SolutionSwitchResult SwitchSolutionMode(SolutionModeConfiguration configuration)
        {
            _shadowCopyHandler.Initialize();
            var solutionConfigFile = _solutionConfigurationFileFactory.Create(configuration.SolutionFilePath);
            _shadowCopyHandler.AddCopy(solutionConfigFile);
            var removedReferences = solutionConfigFile.RemoveReferences(configuration);
            var switchedProjectConfigFiles = new List<ProjectConfigurationFile>();

            foreach (var projectReferenceConfiguration in configuration.ProjectReferenceConfigurations)
            {
                var projectConfigFile = _projectConfigurationFileFactory.Create(projectReferenceConfiguration.AbsoluteProjectFilePath);
                _shadowCopyHandler.AddCopy(projectConfigFile);
                SubstituteProjectConfigReferences(projectConfigFile, removedReferences);
                switchedProjectConfigFiles.Add(projectConfigFile);
            }

            var result = new SolutionSwitchResult(solutionConfigFile, switchedProjectConfigFiles);

            _shadowCopyHandler.Commit();
            return result;
        }

        private void SubstituteProjectConfigReferences(ProjectConfigurationFile projectConfigFile, IEnumerable<SolutionProjectReference> removedReferences)
        {
            foreach (var removedReference in removedReferences)
            {
                var existingProjectReference = projectConfigFile.ProjectReferences.FirstOrDefault(f => f.AssemblyName == removedReference.AssemblyName);
                if (existingProjectReference == null)
                {
                    continue;
                }

                var assemblyReference = _assemblyReferenceFactory.CreateFromProjectReferenceFilePath(
                    removedReference.AbsoluteProjectFilePath,
                    existingProjectReference.RelativeProjectFileIncludePath);

                projectConfigFile.SubstituteProjectReference(existingProjectReference, assemblyReference);
            }
        }
    }
}