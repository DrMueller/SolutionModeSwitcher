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
        private readonly IProjectConfigurationFileRepository _projectConfigurationFileRepository;
        private readonly ISolutionModeShadowCopyCollector _shadowCopyHandler;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public SolutionModeSwitchingService(
            IAssemblyReferenceFromProjectReferenceFactory assemblyReferenceFactory,
            ISolutionConfigurationFileRepository solutionConfigurationFileRepository,
            ISolutionModeShadowCopyCollector shadowCopyHandler,
            IProjectConfigurationFileRepository projectConfigurationFileRepository)
        {
            _assemblyReferenceFactory = assemblyReferenceFactory;
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
            _shadowCopyHandler = shadowCopyHandler;
            _projectConfigurationFileRepository = projectConfigurationFileRepository;
        }

        public SolutionSwitchResult SwitchSolutionMode(SolutionModeConfiguration configuration)
        {
            _shadowCopyHandler.Initialize(configuration.Id);
            var solutionConfigFile = _solutionConfigurationFileRepository.Load(configuration.SolutionFilePath);
            _shadowCopyHandler.SetSolutionConfigurationFileCopy(solutionConfigFile);

            foreach (var projectReferenceConfiguration in configuration.ProjectReferenceConfigurations)
            {
                var projectConfigFile = _projectConfigurationFileRepository.Load(projectReferenceConfiguration.AbsoluteProjectFilePath);
                _projectConfigurationFileRepository.Save(projectConfigFile);

            }

            return null;
        }
    }
}