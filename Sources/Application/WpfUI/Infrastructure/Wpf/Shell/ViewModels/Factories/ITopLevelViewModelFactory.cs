using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.Factories
{
    public interface ITopLevelViewModelFactory
    {
        TopLevelViewModelBase CreateViewModel<T>()
            where T : ViewModelBase;

        TopLevelViewModelBase CreateViewModel(Type viewModelType);
    }
}