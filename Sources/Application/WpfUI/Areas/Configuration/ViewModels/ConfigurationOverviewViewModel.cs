using System.Collections.ObjectModel;
using System.Windows.Input;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ViewModels
{
    public sealed class ConfigurationOverviewViewModel : ViewModelBase, IMainNavigationViewModel
    {
        private readonly IConfigurationNavigationService _configurationNavigationService;
        private readonly IConfigurationService _configurationService;
        private readonly IExceptionHandlingService _exceptionHandler;
        private ObservableCollection<SolutionModeConfigurationDto> _configurations;
        private SolutionModeConfigurationDto _selectedConfiguration;

        public ConfigurationOverviewViewModel(
            IExceptionHandlingService exceptionHandler,
            IConfigurationService configurationService,
            IConfigurationNavigationService configurationNavigationService)
        {
            _exceptionHandler = exceptionHandler;
            _configurationService = configurationService;
            _configurationNavigationService = configurationNavigationService;
            DisplayName = "Configurations";
        }

        public ObservableCollection<SolutionModeConfigurationDto> Configurations
        {
            get => _configurations;
            private set
            {
                _configurations = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand DeleteConfigurationVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Delete",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(DeleteSelectedConfiguration);
                        },
                        () => SelectedConfiguration != null));
            }
        }

        public override string DisplayName { get; protected set; }

        public ICommand EditConfigurationCommand
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        _exceptionHandler.HandledAction(
                            () =>
                            {
                                NavigateToDetails(MaybeFactory.CreateSome(SelectedConfiguration));
                            });
                    },
                    () => SelectedConfiguration != null);
            }
        }

        public ViewModelCommand EditConfigurationVmc => new ViewModelCommand(
            "Edit",
            EditConfigurationCommand);
        public string NavigationDescription => "Configurations";
        public int NavigationSequence => 3;

        public ViewModelCommand NewConfigurationVmc
        {
            get
            {
                return new ViewModelCommand(
                    "New",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(
                                () =>
                                {
                                    NavigateToDetails(MaybeFactory.CreateNone<SolutionModeConfigurationDto>());
                                });
                        }));
            }
        }

        public SolutionModeConfigurationDto SelectedConfiguration
        {
            get => _selectedConfiguration;
            set
            {
                _selectedConfiguration = value;
                OnPropertyChanged();
            }
        }

        public override void OnInit()
        {
            var configurations = _configurationService.LoadAllConfigurations();
            Configurations = new ObservableCollection<SolutionModeConfigurationDto>(configurations);
        }

        private void DeleteSelectedConfiguration()
        {
            _configurationService.DeleteConfiguration(SelectedConfiguration.Id);
            Configurations.Remove(SelectedConfiguration);
            SelectedConfiguration = null;
        }

        private void NavigateToDetails(Maybe<SolutionModeConfigurationDto> configurationMaybe)
        {
            _configurationNavigationService.NavigateToDetails(configurationMaybe);
        }
    }
}