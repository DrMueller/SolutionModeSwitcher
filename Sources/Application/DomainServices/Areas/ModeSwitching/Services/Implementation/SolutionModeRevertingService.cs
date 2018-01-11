using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeRevertingService : ISolutionModeRevertingService
    {
        private readonly ISolutionModeShadowCopyRepository _shadowCopyRepository;
        private readonly ISolutionConfigurationFileFactory _solutionFileConfigFactory;

        public SolutionModeRevertingService(
            ISolutionModeShadowCopyRepository shadowCopyRepository,
            ISolutionConfigurationFileFactory solutionFileConfigFactory)
        {
            _shadowCopyRepository = shadowCopyRepository;
            _solutionFileConfigFactory = solutionFileConfigFactory;
        }

        public SolutionSwitchResult RevertSolutionMode(SolutionModeConfiguration configuration)
        {
            var shadowCopy = _shadowCopyRepository.Load(configuration.Id);
            var solutionFileConfig = _solutionFileConfigFactory.Create(configuration.SolutionFilePath);
            

            
            return null;
        }
    }
}