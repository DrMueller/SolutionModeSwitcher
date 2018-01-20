using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Handlers;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeSwitchingService : ISolutionModeSwitchingService
    {
        private readonly IAssemblyReferenceFromProjectReferenceFactory _assemblyReferenceFactory;
        private readonly IProjectConfigurationFileRepository _projcetConfigurationFileRepository;
        private readonly ISolutionModeShadowCopyCollector _shadowCopyHandler;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public SolutionModeSwitchingService(
            IAssemblyReferenceFromProjectReferenceFactory assemblyReferenceFactory,
            ISolutionConfigurationFileRepository solutionConfigurationFileRepository,
            ISolutionModeShadowCopyCollector shadowCopyHandler,
            IProjectConfigurationFileRepository projcetConfigurationFileRepository)
        {
            _assemblyReferenceFactory = assemblyReferenceFactory;
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
            _shadowCopyHandler = shadowCopyHandler;
            _projcetConfigurationFileRepository = projcetConfigurationFileRepository;
        }

        public SolutionSwitchResult SwitchSolutionMode(SolutionModeConfiguration configuration)
        {
            _shadowCopyHandler.Initialize(configuration.Id);
            var solutionConfigFile = _solutionConfigurationFileRepository.Load(configuration.SolutionFilePath);
            _shadowCopyHandler.SetSolutionConfigurationFileCopy(solutionConfigFile);

            var projectReferenceAssemblyNames = configuration.ProjectReferenceConfigurations.Select(f => f.AssemblyName).ToList();
            var removedReferences = solutionConfigFile.RemoveProjectReferencesExcept(projectReferenceAssemblyNames);
            var switchedProjectConfigFiles = new List<ProjectConfigurationFile>();

            foreach (var projectReferenceConfiguration in configuration.ProjectReferenceConfigurations)
            {
                var projectConfigFile = _projcetConfigurationFileRepository.Load(projectReferenceConfiguration.AbsoluteProjectFilePath);
                _shadowCopyHandler.AddProjectConfigurationFileCopy(projectConfigFile);
                SubstituteProjectConfigReferences(projectConfigFile, removedReferences);
                switchedProjectConfigFiles.Add(projectConfigFile);
            }

            var result = new SolutionSwitchResult(solutionConfigFile, switchedProjectConfigFiles);

            _shadowCopyHandler.Save();
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