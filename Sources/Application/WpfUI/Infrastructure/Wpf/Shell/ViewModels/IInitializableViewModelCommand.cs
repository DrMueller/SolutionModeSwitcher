namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public interface IInitializableViewModelCommand<in TViewModel> : IViewModelCommand
        where TViewModel : ViewModelBase
    {
        void Initialize(TViewModel context);
    }
}