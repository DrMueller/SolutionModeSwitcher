using System.Windows;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.Views;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.AppStart
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            BootstrapService.Initialize();
            var viewContainer = ProvisioningServiceSingleton.Instance.GetService<ViewContainer>();
            viewContainer.ShowDialog();
        }
    }
}