using System.Windows;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.Views.ViewBehaviors;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.Views
{
    /// <summary>
    ///     Interaction logic for ViewContainer.xaml
    /// </summary>
    public partial class ViewContainer : Window, IClosable
    {
        public ViewContainer(ViewModelContainer viewModelContainer)
        {
            DataContext = viewModelContainer;
            InitializeComponent();
        }
    }
}