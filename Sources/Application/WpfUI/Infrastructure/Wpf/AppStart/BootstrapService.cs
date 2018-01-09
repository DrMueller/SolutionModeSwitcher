using Mmu.Sms.Application.Infrastructure.Ioc;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.AppStart
{
    internal static class BootstrapService
    {
        internal static void Initialize()
        {
            IocInitialization.InitializeProvisioningService();
            ViewModelMappingInitializationService.Initialize();
        }
    }
}