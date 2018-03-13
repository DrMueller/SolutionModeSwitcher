using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Factories;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Services.Implementation
{
    public class BuildableProjectsSearchService : IBuildableProjectsSearchService
    {
        private readonly IBuildableProjectViewModelFactory _buildableProjectViewModelFactory;
        private readonly IInformationPublishingService _informationPublishingService;
        private readonly IProjectSearchService _projectSearchService;

        public BuildableProjectsSearchService(
            IProjectSearchService projectSearchService,
            IInformationPublishingService informationPublishingService,
            IBuildableProjectViewModelFactory buildableProjectViewModelFactory)
        {
            _projectSearchService = projectSearchService;
            _informationPublishingService = informationPublishingService;
            _buildableProjectViewModelFactory = buildableProjectViewModelFactory;
        }

        public async Task<IReadOnlyCollection<BuildableProjectViewModel>> SearchProjectsAsync(SolutionModeConfigurationDto configuration)
        {
            _informationPublishingService.Publish(InformationType.Important, "Searching Projects...");
            var projectDtos = await _projectSearchService.SearchProjectsAsync(configuration);
            var result = MapDtosToViewModels(projectDtos);

            _informationPublishingService.Publish(InformationType.Success, "Searching finished!");
            return result;
        }

        private IReadOnlyCollection<BuildableProjectViewModel> MapDtosToViewModels(IReadOnlyCollection<BuildableProjectDto> projectDtos)
        {
            var result = new List<BuildableProjectViewModel>();
            foreach (var projDto in projectDtos)
            {
                var viewModel = _buildableProjectViewModelFactory.Create(projDto.FilePath);
                result.Add(viewModel);
            }

            return result;
        }
    }
}