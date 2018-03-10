using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Services.Threading;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public sealed class ProjectBuildingViewModel : TopLevelViewModelBase, IMainNavigationViewModel
    {
        private readonly IConfigurationService _configurationService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IBuildableProjectsSearchService _projectBuildingService;
        private readonly IThreadingService _threadingService;
        private IReadOnlyCollection<BuildableProjectViewModel> _buildableProjects;
        private IReadOnlyCollection<SolutionModeConfigurationDto> _configurations;
        private bool _isBuildInProgress;
        private Queue<BuildableProjectViewModel> _queudBuilds;
        private bool _queuing;

        public ProjectBuildingViewModel(
            IInformationConfigurationService informationConfigurationService,
            IThreadingService threadingService,
            IConfigurationService configurationService,
            IBuildableProjectsSearchService projectBuildingService,
            IExceptionHandlingService exceptionHandlingService)
        {
            _threadingService = threadingService;
            _configurationService = configurationService;
            _projectBuildingService = projectBuildingService;
            _exceptionHandlingService = exceptionHandlingService;
            informationConfigurationService.RegisterForAllTypes(InformationReceived);

            Informations = new ObservableCollection<Information>();
            _queudBuilds = new Queue<BuildableProjectViewModel>();
            DisplayName = "Project Building";
        }

        public IReadOnlyCollection<BuildableProjectViewModel> BuildableProjects
        {
            get => _buildableProjects;
            private set
            {
                _buildableProjects = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCommand BuildAllProjectsVmc => new ViewModelCommand(
            "Build all",
            new RelayCommand(BuildAllProjectsAsync));

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
                                    BuildableProjects = await _projectBuildingService.SearchProjectsAsync(SelectedConfiguration);
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

        public ICommand QueueBuild()
        {
            return new ParametredRelayCommand(
                obj =>
                {
                    var buildableProject = (BuildableProjectViewModel)obj;
                    StartQueue(buildableProject);
                });
        }

        private void BuildAllProjectsAsync()
        {
            foreach (var proj in BuildableProjects)
            {
                StartQueue(proj);
            }
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

        private async void StartQueue(BuildableProjectViewModel buildableProject)
        {
            _queudBuilds.Enqueue(buildableProject);

            if (_queuing)
            {
                return;
            }

            _queuing = true;

            var next = _queudBuilds.Dequeue();
            while (next != null)
            {
                await next.BuildProjectAsync();
                next = _queudBuilds.Dequeue();
            }

            _queuing = false;
        }
    }
}