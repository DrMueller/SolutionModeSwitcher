using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.WpfUI.Areas.Configuration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ViewModels
{
    public sealed class ProjectSelectionViewModel : TopLevelViewModelBase
    {
        private readonly IConfigurationNavigationService _configurationNavigationService;
        private readonly IExceptionHandlingService _exceptionHandler;
        private SolutionModeConfigurationDto _configuration;
        private ICollectionView _projects;
        private string _projectsFilter;

        public ProjectSelectionViewModel(
            IExceptionHandlingService exceptionHandler,
            IConfigurationNavigationService configurationNavigationService)
        {
            _exceptionHandler = exceptionHandler;
            _configurationNavigationService = configurationNavigationService;
            DisplayName = "Project selection";
        }

        public ViewModelCommand AddSelectedProjectsVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Add selection",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(
                                () =>
                                {
                                    ApplySelectedProjects();
                                    _configurationNavigationService.NavigateToDetails(MaybeFactory.CreateSome(_configuration));
                                });
                        }));
            }
        }

        public ViewModelCommand CancelVmc
        {
            get
            {
                return new ViewModelCommand(
                    "Cancel",
                    new RelayCommand(
                        () =>
                        {
                            _exceptionHandler.HandledAction(
                                () =>
                                {
                                    _configurationNavigationService.NavigateToDetails(MaybeFactory.CreateSome(_configuration));
                                });
                        }));
            }
        }

        public override string DisplayName { get; protected set; }

        public ICollectionView Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }

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
                Projects.Refresh();
                OnPropertyChanged();
            }
        }

        public void Initialize(SolutionModeConfigurationDto configuration, IReadOnlyCollection<SelectProjectDto> projects)
        {
            _configuration = configuration;
            Projects = CollectionViewSource.GetDefaultView(projects);
            Projects.Filter += FilterProject;
        }

        private void ApplySelectedProjects()
        {
            var selectedReferences = Projects.SourceCollection.Cast<SelectProjectDto>().Where(f => f.IsSelected).Select(
                f => new ProjectReferenceConfigurationDto
                {
                    AbsoluteProjectFilePath = f.AbsoluteProjectFilePath,
                    AssemblyName = f.AssemblyName
                }).ToList();

            _configuration.ProjectReferenceConfigurations = selectedReferences;
        }

        private bool FilterProject(object obj)
        {
            if (string.IsNullOrEmpty(ProjectsFilter))
            {
                return true;
            }
            var project = (SelectProjectDto)obj;
            return project.AssemblyName.ToUpperInvariant().Contains(ProjectsFilter.ToUpper());
        }
    }
}