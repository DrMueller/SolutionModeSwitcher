using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
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
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public sealed class ProjectBuildingViewModel : TopLevelViewModelBase, IMainNavigationViewModel
    {
        private readonly IBuildableProjectSearchService _buildableProjectSearchService;
        private readonly IConfigurationService _configurationService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IThreadingService _threadingService;
        private ICollectionView _buildableProjects;
        private IReadOnlyCollection<SolutionModeConfigurationDto> _configurations;
        private bool _isBuildInProgress;
        private string _projectsFilter;
        private Queue<BuildableProjectViewModel> _queudBuilds;
        private bool _queuing;

        public ProjectBuildingViewModel(
            IInformationConfigurationService informationConfigurationService,
            IThreadingService threadingService,
            IConfigurationService configurationService,
            IBuildableProjectSearchService buildableProjectSearchService,
            IExceptionHandlingService exceptionHandlingService)
        {
            _threadingService = threadingService;
            _configurationService = configurationService;
            _buildableProjectSearchService = buildableProjectSearchService;
            _exceptionHandlingService = exceptionHandlingService;
            informationConfigurationService.RegisterForAllTypes(InformationReceived);

            Informations = new ObservableCollection<Information>();
            _queudBuilds = new Queue<BuildableProjectViewModel>();
            DisplayName = "Project Building";
        }

        public ICollectionView BuildableProjects
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

        public string ProjectsFilter
        {
            get => _projectsFilter;
            set
            {
                if (_projectsFilter == value)
                {
                    return;
                }

                _projectsFilter = value;
                BuildableProjects.Refresh();
                OnPropertyChanged();
            }
        }

        public ICommand QueueBuild => new ParametredRelayCommand(
            obj =>
            {
                var buildableProject = (BuildableProjectViewModel)obj;
                AddProjectToQueue(buildableProject);
                StartQueue();
            });

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
                                    var buildableProjects = await _buildableProjectSearchService.SearchProjectsAsync(SelectedConfiguration);
                                    BuildableProjects = CollectionViewSource.GetDefaultView(buildableProjects);
                                    BuildableProjects.Filter += FilterBuildableProject;
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

        private void AddProjectToQueue(BuildableProjectViewModel project)
        {
            if (_queudBuilds.Contains(project))
            {
                return;
            }

            _queudBuilds.Enqueue(project);
            project.SetAsEnqueued();
        }

        private void BuildAllProjectsAsync()
        {
            foreach (BuildableProjectViewModel proj in BuildableProjects)
            {
                AddProjectToQueue(proj);
            }

            StartQueue();
        }

        private bool CanSearchProjects()
        {
            return SelectedConfiguration != null && !_isBuildInProgress;
        }

        private bool FilterBuildableProject(object obj)
        {
            if (string.IsNullOrEmpty(ProjectsFilter))
            {
                return true;
            }
            var project = (BuildableProjectViewModel)obj;
            return project.FileName.ToUpperInvariant().Contains(ProjectsFilter.ToUpper());
        }

        private void InformationReceived(Information information)
        {
            _threadingService.InvokeOnUiThread(
                () =>
                {
                    Informations.Insert(0, information);
                });
        }

        private async void StartQueue()
        {
            if (_queuing)
            {
                return;
            }

            _queuing = true;

            while (_queudBuilds.Count > 0)
            {
                var projectToBuild = _queudBuilds.Dequeue();
                await projectToBuild.BuildProjectAsync();
            }

            _queuing = false;
        }
    }
}