using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Services.Threading;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public sealed class ProjectBuildingViewModel : ViewModelBase, IMainNavigationViewModel
    {
        private readonly IConfigurationService _configurationService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IProjectBuildingService _projectBuildingService;
        private readonly IProjectBuildService _projectBuildService;
        private readonly IThreadingService _threadingService;
        private IReadOnlyCollection<BuildableProjectVm> _buildableProjects;
        private IReadOnlyCollection<SolutionModeConfigurationDto> _configurations;
        private bool _isBuildInProgress;

        public ProjectBuildingViewModel(
            IInformationConfigurationService informationConfigurationService,
            IThreadingService threadingService,
            IConfigurationService configurationService,
            IProjectBuildingService projectBuildingService,
            IProjectBuildService projectBuildService,
            IExceptionHandlingService exceptionHandlingService)
        {
            _threadingService = threadingService;
            _configurationService = configurationService;
            _projectBuildingService = projectBuildingService;
            _projectBuildService = projectBuildService;
            _exceptionHandlingService = exceptionHandlingService;
            informationConfigurationService.RegisterForAllTypes(InformationReceived);

            Informations = new ObservableCollection<Information>();
            DisplayName = "Project Building";
        }

        public IReadOnlyCollection<BuildableProjectVm> BuildableProjects
        {
            get => _buildableProjects;
            private set
            {
                _buildableProjects = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand BuildAllProjectsVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Build all",
                    new RelayCommand(
                        async () =>
                        {
                            await _projectBuildingService.BuildProjectsAsync(BuildableProjects);
                        }));
            }
        }

        public IReadOnlyCollection<SolutionModeConfigurationDto> Configurations
        {
            get => _configurations;
            set
            {
                _configurations = value;
                OnPropertyChanged();
            }
        }

        public override string DisplayName { get; protected set; }
        public ObservableCollection<Information> Informations { get; }
        public string NavigationDescription => "Building";
        public int NavigationSequence => 2;

        public ViewModelCommand SearchProjectsVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Search Projects",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandlingService.HandledActionAsync(
                                async () =>
                                {
                                    _isBuildInProgress = true;
                                    BuildableProjects = await _projectBuildingService.SearchProjectsAsync(SelectedConfiguration, BuildProjectRequested);
                                },
                                () => _isBuildInProgress = false);
                        },
                        CanSearchProjects));
            }
        }

        public SolutionModeConfigurationDto SelectedConfiguration { get; set; }

        public override void OnInit()
        {
            Configurations = _configurationService.LoadAllConfigurations();
        }

        private async Task BuildProjectRequested(string filePath)
        {
            await _projectBuildService.BuildProjectAsync(filePath);
        }

        private bool CanSearchProjects()
        {
            return SelectedConfiguration != null && !_isBuildInProgress;
        }

        private void InformationReceived(Information information)
        {
            _threadingService.InvokeOnUiThread(
                () =>
                {
                    Informations.Insert(0, information);
                });
        }
    }
}