using Microsoft.Win32;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services.Handlers.Implementation
{
    public class RegistryHandler : IRegistryHandler
    {
        public string LoadFromCurrentUserApplicationRegistry(string keyName)
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            var result = (string)regKey.GetValue(keyName, string.Empty);

            return result;
        }

        public void SaveIntoCurrentUserApplicationRegistry(string keyName, string value)
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            regKey.SetValue(keyName, value);
            regKey.Close();
        }

        private static RegistryKey GetCurrentUserApplicationRegistryKey()
        {
            var assemblyName = typeof(RegistryHandler).Assembly.GetName().Name;
            var subKey = string.Concat("SOFTWARE", @"\", assemblyName);
            var result = Registry.CurrentUser.CreateSubKey(subKey);

            return result;
        }
    }
}