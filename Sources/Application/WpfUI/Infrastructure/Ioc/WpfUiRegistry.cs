using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using StructureMap;

namespace Mmu.Sms.WpfUI.Infrastructure.Ioc
{
    public class WpfUiRegistry : Registry
    {
        public WpfUiRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.AddAllTypesOf<ViewModelBase>();
                    scan.WithDefaultConventions();
                });

            For<INavigationService>().Singleton();
            For<INavigationConfigurationService>().Singleton();
            For<IAppearanceService>().Singleton();
            For<IExceptionHandlingService>().Singleton();
            For<IExceptionConfigurationService>().Singleton();
            For<IExceptionLoggingService>().Singleton();
            For<INavigationService>().Singleton();
            For<INavigationConfigurationService>().Singleton();
        }
    }
}