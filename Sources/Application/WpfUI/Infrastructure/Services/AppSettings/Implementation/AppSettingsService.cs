using System.Configuration;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.AppSettings.Implementation
{
    public class AppSettingsService : IAppSettingsService
    {
        public string GetConfigurationDirectory()
        {
            var result = ConfigurationManager.AppSettings["ConfigurationDirectory"];
            return result;
        }

        public string GetDefaultSolutionFilePath()
        {
            var result = ConfigurationManager.AppSettings["DefaultSolutionFilePath"];
            return result;
        }
    }
}