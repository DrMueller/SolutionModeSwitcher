using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeSwitchingService : ISolutionModeSwitchingService
    {
        private readonly IProjectConfigurationFileRepository _projectConfigurationFileRepository;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public SolutionModeSwitchingService(
            IAssemblyReferenceFromProjectReferenceFactory assemblyReferenceFactory,
            ISolutionConfigurationFileRepository solutionConfigurationFileRepository,
            IProjectConfigurationFileRepository projectConfigurationFileRepository)
        {
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
            _projectConfigurationFileRepository = projectConfigurationFileRepository;
        }

        public SolutionSwitchResult SwitchSolutionMode(SolutionModeConfiguration configuration)
        {
            var solutionConfigFile = _solutionConfigurationFileRepository.Load(configuration.SolutionFilePath);

            foreach (var projectReferenceConfiguration in configuration.ProjectReferenceConfigurations)
            {
                var projectConfigFile = _projectConfigurationFileRepository.Load(projectReferenceConfiguration.AbsoluteProjectFilePath);
                _projectConfigurationFileRepository.Save(projectConfigFile);
            }

            return null;
        }
    }
}