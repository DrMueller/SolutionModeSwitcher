namespace Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services.Handlers
{
    public interface IRegistryHandler
    {
        string LoadFromCurrentUserApplicationRegistry(string keyName);

        void SaveIntoCurrentUserApplicationRegistry(string keyName, string value);
    }
}