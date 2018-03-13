using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.Confguration.Services;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.WpfUI.Areas.Configuration.Services.Handlers;
using Mmu.Sms.WpfUI.Areas.Configuration.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services.Implementation
{
    public class ProjectSelectionNavigationService : IProjectSelectionNavigationService
    {
        private readonly INavigationService _navigationHandler;
        private readonly IProjectSelectionService _projectSelectionService;
        private readonly IProvisioningService _provisioningService;
        private readonly ISelectProjectDtoMappingHandler _selectProjectDtoMappingHandler;

        public ProjectSelectionNavigationService(
            INavigationService navigationHandler,
            IProvisioningService provisioningService,
            IProjectSelectionService projectSelectionService,
            ISelectProjectDtoMappingHandler selectProjectDtoMappingHandler)
        {
            _navigationHandler = navigationHandler;
            _provisioningService = provisioningService;
            _projectSelectionService = projectSelectionService;
            _selectProjectDtoMappingHandler = selectProjectDtoMappingHandler;
        }

        public void NavigateToProjectSelection(SolutionModeConfigurationDto configuration)
        {
            var viewModel = _provisioningService.GetService<ProjectSelectionViewModel>();

            var projectsInSolution = _projectSelectionService.LoadProjects(configuration.SolutionFilePath);
            var selectProjects = _selectProjectDtoMappingHandler.Map(projectsInSolution, configuration);

            viewModel.Initialize(configuration, selectProjects);
            _navigationHandler.NavigateTo(viewModel);
        }
    }
}