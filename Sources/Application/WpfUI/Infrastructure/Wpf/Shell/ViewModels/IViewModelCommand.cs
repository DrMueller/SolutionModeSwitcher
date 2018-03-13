using System.Windows.Input;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public interface IViewModelCommand
    {
        ICommand Command { get; }
        string Description { get; }
    }
}