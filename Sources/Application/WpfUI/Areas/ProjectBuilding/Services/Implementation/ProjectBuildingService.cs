using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Services.Implementation
{
    public class ProjectBuildingService : IProjectBuildingService
    {
        private readonly IInformationPublishingService _informationPublishingService;
        private readonly IProjectSearchService _projectSearchService;

        public ProjectBuildingService(IProjectSearchService projectSearchService, IInformationPublishingService informationPublishingService)
        {
            _projectSearchService = projectSearchService;
            _informationPublishingService = informationPublishingService;
        }

        public async Task BuildProjectsAsync(IReadOnlyCollection<BuildableProjectViewModel> projects)
        {
            _informationPublishingService.Publish(InformationType.Important, "Build build Okey Dokey...");
            foreach (var proj in projects)
            {
                await proj.BuildProjectAsync();
            }

            _informationPublishingService.Publish(InformationType.Success, "Builds finished!");
        }

        public async Task<IReadOnlyCollection<BuildableProjectViewModel>> SearchProjectsAsync(SolutionModeConfigurationDto configuration, Func<string, Task> buildRequestedCallback)
        {
            _informationPublishingService.Publish(InformationType.Important, "Searching Projects...");
            var projectDtos = await _projectSearchService.SearchProjectsAsync(configuration);
            var result = projectDtos.Select(f => new BuildableProjectViewModel(f.FilePath, f.FileName, buildRequestedCallback)).ToList();
            _informationPublishingService.Publish(InformationType.Success, "Searching finished!");
            return result;
        }
    }
}