using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services
{
    public interface IAppearanceService
    {
        AppearanceTheme LoadPersistedAppearanceTheme();

        void SetAndPersistAppearanceTheme(AppearanceTheme appearanceTheme);
    }
}