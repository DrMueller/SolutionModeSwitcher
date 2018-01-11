using System;
using System.Threading.Tasks;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.ProjectBuildStateImplementations
{
    public class ReadyToBuildState : IProjectBuildState
    {
        private readonly IProjectBuildService _projectBuildService;
        private readonly IProjectBuildStateFactory _projectBuildStateFactory;

        public ReadyToBuildState(IProjectBuildService projectBuildService, IProjectBuildStateFactory projectBuildStateFactory)
        {
            _projectBuildService = projectBuildService;
            _projectBuildStateFactory = projectBuildStateFactory;
        }

        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Cog_Green.png";
        public bool IsBuildInProgress => false;
        public bool IsTooltipVisible => false;
        public string TooltipText => string.Empty;

        public async Task StartBuildingAsync(
            string filePath,
            Action<IProjectBuildState> stateChangedCallback)
        {
            try
            {
                stateChangedCallback(_projectBuildStateFactory.CreateBuildInProgressState());
                await _projectBuildService.BuildProjectAsync(filePath);
                stateChangedCallback(_projectBuildStateFactory.CreateReadyToBuildState());
            }
            catch (Exception exception)
            {
                stateChangedCallback(_projectBuildStateFactory.CreateBuildErrorState(exception));
            }
        }
    }
}