using System;
using MaterialDesignThemes.Wpf;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Models;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services.Handlers;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services.Implementation
{
    public class AppearanceService : IAppearanceService
    {
        private const string RegistryKeyAppearanceTheme = "AppearanceTheme";
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private readonly IRegistryHandler _registryHandler;

        public AppearanceService(IRegistryHandler registryHandler)
        {
            _registryHandler = registryHandler;
        }

        public AppearanceTheme LoadPersistedAppearanceTheme()
        {
            var savedTheme = _registryHandler.LoadFromCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme);
            var appearanceTheme = AppearanceTheme.Light;
            if (!string.IsNullOrEmpty(savedTheme))
            {
                appearanceTheme = (AppearanceTheme)Enum.Parse(typeof(AppearanceTheme), savedTheme);
            }

            return appearanceTheme;
        }

        public void SetAndPersistAppearanceTheme(AppearanceTheme appearanceTheme)
        {
            _paletteHelper.SetLightDark(appearanceTheme == AppearanceTheme.Dark);
            _registryHandler.SaveIntoCurrentUserApplicationRegistry(RegistryKeyAppearanceTheme, appearanceTheme.ToString());
        }
    }
}