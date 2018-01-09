using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services
{
    public interface IConfigurationNavigationService
    {
        void NavigateToDetails(Maybe<SolutionModeConfigurationDto> configurationMaybe);
    }
}
