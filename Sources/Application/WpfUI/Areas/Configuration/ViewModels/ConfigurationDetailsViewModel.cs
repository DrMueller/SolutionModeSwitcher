using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.WpfUI.Areas.Common.ValidationExpressions;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Areas.Configuration.ValidationExpressions;
using Mmu.Sms.WpfUI.Infrastructure.Services.AppSettings;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Services.FileDialog.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ViewModels
{
    public class ConfigurationDetailsViewModel : TopLevelViewModelBase
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly IConfigurationService _configurationService;
        private readonly IExceptionHandlingService _exceptionHandler;
        private readonly IFileDialogService _fileDialogService;
        private readonly INavigationService _navigationHandler;
        private readonly IProjectSelectionNavigationService _projectSelectionNavigationService;
        private SolutionModeConfigurationDto _configuration;
        private string _configurationName;
        private string _solutionFilePath;

        public ConfigurationDetailsViewModel(
            INavigationService navigationHandler,
            IExceptionHandlingService exceptionHandler,
            IFileDialogService fileDialogService,
            IConfigurationService configurationService,
            IProjectSelectionNavigationService projectSelectionNavigationService,
            IAppSettingsService appSettingsService)
        {
            _navigationHandler = navigationHandler;
            _exceptionHandler = exceptionHandler;
            _fileDialogService = fileDialogService;
            _configurationService = configurationService;
            _projectSelectionNavigationService = projectSelectionNavigationService;
            _appSettingsService = appSettingsService;
        }

        public ViewModelCommand CancelVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Close",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(NavigateToOverview);
                        }));
            }
        }

        public string ConfigurationName
        {
            get => _configurationName;
            set
            {
                if (_configurationName == value)
                {
                    return;
                }

                _configurationName = value;
                OnPropertyChanged();
            }
        }

        public override string DisplayName { get; protected set; }

        public ViewModelCommand SaveConfigurationVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Save",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(SaveConfiguration);
                        },
                        () => !HasErrors));
            }
        }

        public int SelectedProjectsCount => _configuration.ProjectReferencesCount;

        public ViewModelCommand SelectProjectsMvc
        {
            get
            {
                return new ViewModelCommand(
                    "Projects",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(
                                () =>
                                    _projectSelectionNavigationService.NavigateToProjectSelection(_configuration));
                        },
                        CanSelectProjects));
            }
        }

        public ViewModelCommand SelectSolutionFilePathVmc
        {
            get
            {
                return new ViewModelCommand(
                    "..",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(
                                () =>
                                {
                                    var selectFileResult = _fileDialogService.SelectFileName("VS Solution files|*.sln");
                                    if (selectFileResult.OkClicked)
                                    {
                                        SolutionFilePath = selectFileResult.FilePath;
                                    }
                                });
                        }));
            }
        }

        public string SolutionFilePath
        {
            get => _solutionFilePath;
            set
            {
                if (_solutionFilePath == value)
                {
                    return;
                }

                _solutionFilePath = value;
                OnPropertyChanged();
            }
        }

        public void Initialize(Maybe<SolutionModeConfigurationDto> configurationMaybe)
        {
            configurationMaybe.Evaluate(
                InitializeEdit,
                InitializeNew);
        }

        public override void OnInit()
        {
            AddValidation(nameof(SolutionFilePath), new FileExistsValidationExpression());
            AddValidation(nameof(SolutionFilePath), new FileIsSolutionFileValidationExpression());
            AddValidation(nameof(SolutionFilePath), new StringNotNullOrEmptyValidationExpression());
            AddValidation(nameof(ConfigurationName), new StringNotNullOrEmptyValidationExpression());
        }

        private bool CanSelectProjects()
        {
            return !string.IsNullOrEmpty(_configuration.SolutionFilePath);
        }

        private void InitializeEdit(SolutionModeConfigurationDto configuration)
        {
            _configuration = configuration;
            SetValuesFromModel();
            DisplayName = "Edit Configuration";
        }

        private void InitializeNew()
        {
            _configuration = new SolutionModeConfigurationDto();
            SetValuesFromModel();
            DisplayName = "New Configuration";
            SolutionFilePath = _appSettingsService.GetDefaultSolutionFilePath();
        }

        private void NavigateToOverview()
        {
            _navigationHandler.NavigateTo<ConfigurationOverviewViewModel>();
        }

        private void SaveConfiguration()
        {
            _configuration.ConfigurationName = ConfigurationName;
            _configuration.SolutionFilePath = SolutionFilePath;
            _configuration = _configurationService.SaveConfiguration(_configuration);
        }

        private void SetValuesFromModel()
        {
            ConfigurationName = _configuration.ConfigurationName;
            SolutionFilePath = _configuration.SolutionFilePath;
        }
    }
}