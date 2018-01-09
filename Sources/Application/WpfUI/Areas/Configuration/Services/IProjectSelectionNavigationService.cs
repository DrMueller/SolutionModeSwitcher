using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services
{
    public interface IProjectSelectionNavigationService
    {
        void NavigateToProjectSelection(SolutionModeConfigurationDto configuration);
    }
}