using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeRevertingService : ISolutionModeRevertingService
    {
        private readonly ISolutionModeShadowCopyRepository _shadowCopyRepository;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public SolutionModeRevertingService(
            ISolutionModeShadowCopyRepository shadowCopyRepository,
            ISolutionConfigurationFileRepository solutionConfigurationFileRepository)
        {
            _shadowCopyRepository = shadowCopyRepository;
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
        }

        public SolutionSwitchResult RevertSolutionMode(SolutionModeConfiguration configuration)
        {
            var shadowCopy = _shadowCopyRepository.Load(configuration.Id);
            var solutionFileConfig = _solutionConfigurationFileRepository.Load(configuration.SolutionFilePath);

            
            return null;
        }
    }
}