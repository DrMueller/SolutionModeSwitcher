using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Services
{
    public interface IProjectBuildingService
    {
        Task<IReadOnlyCollection<BuildableProjectViewModel>> SearchProjectsAsync(SolutionModeConfigurationDto configuration, Func<string, Task> buildRequestedCallback);

        Task BuildProjectsAsync(IReadOnlyCollection<BuildableProjectViewModel> projects);
    }
}