namespace Mmu.Sms.WpfUI.Infrastructure.Services.AppSettings
{
    public interface IAppSettingsService
    {
        string GetConfigurationDirectory();

        string GetDefaultSolutionFilePath();
    }
}