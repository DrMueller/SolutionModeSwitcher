using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Models;
using Mmu.Sms.WpfUI.Infrastructure.Services.Appearance.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Services.MainNavigation.Initialization;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.Views.ViewBehaviors;
using Mmu.Sms.WpfUI.Properties;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public sealed class ViewModelContainer : INotifyPropertyChanged
    {
        private readonly IAppearanceService _appearanceService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IMainNavigationInitializingService _mainNavigationInitializer;
        private TopLevelViewModelBase _currentContent;
        private string _informationText;
        private bool _isMainNavigationPaneOpen;
        private AppearanceTheme _selectedAppearanceTheme;

        public ViewModelContainer(
            IAppearanceService appearanceService,
            IExceptionHandlingService exceptionHandlingService,
            IExceptionConfigurationService exceptionConfigurationService,
            IInformationConfigurationService informationConfigurationService,
            INavigationConfigurationService navigationConfigurationService,
            IMainNavigationInitializingService mainNavigationInitializer)
        {
            _appearanceService = appearanceService;
            _exceptionHandlingService = exceptionHandlingService;
            _mainNavigationInitializer = mainNavigationInitializer;
            exceptionConfigurationService.AddExceptionCallback(ShowExceptionMessageCallback);
            navigationConfigurationService.AddNavigationRequestedCallback(NavigateToViewModelCallback);
            informationConfigurationService.RegisterForTypes(
                ShowInformationMessageCallback,
                InformationType.Error,
                InformationType.Important,
                InformationType.Success,
                InformationType.Warning);

            SelectedAppearanceTheme = _appearanceService.LoadPersistedAppearanceTheme();
            _mainNavigationInitializer.NavigateToMainEntryPoint();
        }

        public ParametredRelayCommand CloseCommand
        {
            get
            {
                return new ParametredRelayCommand(
                    o =>
                    {
                        var closable = (IClosable)o;
                        closable.Close();
                    });
            }
        }

        public ICommand CloseMainNavigationPane
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        IsMainNavigationPaneOpen = false;
                    });
            }
        }

        public ViewModelCommand CloseVmc => new ViewModelCommand("Close App", CloseCommand);

        public TopLevelViewModelBase CurrentContent
        {
            get => _currentContent;
            private set
            {
                if (_currentContent == value)
                {
                    return;
                }

                _currentContent = value;
                _currentContent.OnInit();
                OnPropertyChanged();
            }
        }

        public string InformationText
        {
            get => _informationText;
            private set
            {
                if (_informationText == value)
                {
                    return;
                }

                _informationText = value;
                OnPropertyChanged();
            }
        }

        public bool IsMainNavigationPaneOpen
        {
            get => _isMainNavigationPaneOpen;
            set
            {
                if (_isMainNavigationPaneOpen == value)
                {
                    return;
                }

                _isMainNavigationPaneOpen = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ViewModelCommand> MainNavigationEntries
        {
            get
            {
                return _exceptionHandlingService.HandledFunction(() => _mainNavigationInitializer.GetOrderedMainNavigationEntries());
            }
        }

        public AppearanceTheme SelectedAppearanceTheme
        {
            get => _selectedAppearanceTheme;
            set
            {
                _appearanceService.SetAndPersistAppearanceTheme(value);
                _selectedAppearanceTheme = value;
            }
        }

        private void NavigateToViewModelCallback(TopLevelViewModelBase viewModelBase)
        {
            CurrentContent = viewModelBase;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PublishInformation(string message)
        {
            InformationText = message;
        }

        private void ShowExceptionMessageCallback(Exception ex)
        {
            var text = ex.Message;
            PublishInformation(text);
        }

        private async void ShowInformationMessageCallback(Information information)
        {
            PublishInformation(information.InformationText);
            await Task.Delay(5000);
            PublishInformation(string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}