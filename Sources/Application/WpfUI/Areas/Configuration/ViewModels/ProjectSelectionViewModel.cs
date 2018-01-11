using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.WpfUI.Areas.Configuration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ViewModels
{
    public sealed class ProjectSelectionViewModel : TopLevelViewModelBase
    {
        private readonly IConfigurationNavigationService _configurationNavigationService;
        private readonly IExceptionHandlingService _exceptionHandler;
        private SolutionModeConfigurationDto _configuration;
        private IReadOnlyCollection<SelectProjectDto> _projects;

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

        public IReadOnlyCollection<SelectProjectDto> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged();
            }
        }

        public void Initialize(SolutionModeConfigurationDto configuration, IReadOnlyCollection<SelectProjectDto> projects)
        {
            _configuration = configuration;
            Projects = projects;
        }

        private void ApplySelectedProjects()
        {
            var selectedReferences = Projects.Where(f => f.IsSelected).Select(
                f => new ProjectReferenceConfigurationDto
                {
                    AbsoluteProjectFilePath = f.AbsoluteProjectFilePath,
                    AssemblyName = f.AssemblyName
                }).ToList();

            _configuration.ProjectReferenceConfigurations = selectedReferences;
        }
    }
}