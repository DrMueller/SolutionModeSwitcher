using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;

namespace Mmu.Sms.Application.Areas.Domain.ModeSwitching.Services
{
    public interface ISolutionSwitchingService
    {
        void SwitchSolution(SolutionModeConfigurationDto configurationDto);
    }
}