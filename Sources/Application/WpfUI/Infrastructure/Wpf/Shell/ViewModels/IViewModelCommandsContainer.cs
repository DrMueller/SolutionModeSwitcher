namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public interface IViewModelCommandsContainer<in TViewModel>
        where TViewModel : ViewModelBase
    {
        void Initialize(TViewModel context);
    }
}