using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel<T>()
            where T : ViewModelBase;

        ViewModelBase CreateViewModel(Type viewModelType);
    }
}