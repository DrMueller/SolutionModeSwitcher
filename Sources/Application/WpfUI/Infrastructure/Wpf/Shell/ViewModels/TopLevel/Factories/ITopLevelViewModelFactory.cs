using System;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel.Factories
{
    public interface ITopLevelViewModelFactory
    {
        TopLevelViewModelBase CreateViewModel<T>()
            where T : ViewModelBase;

        TopLevelViewModelBase CreateViewModel(Type viewModelType);
    }
}