using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.ProjectBuildStateImplementations
{
    public class BuildEnqueuedState : IProjectBuildState
    {
        private readonly IProjectBuildStateFactory _projectBuildStateFactory;

        public BuildEnqueuedState(IProjectBuildStateFactory projectBuildStateFactory)
        {
            _projectBuildStateFactory = projectBuildStateFactory;
        }

        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Arrow.png";
        public bool IsBuildInProgress => false;
        public bool IsTooltipVisible => false;
        public string TooltipText => string.Empty;

        public async Task StartBuildingAsync(string filePath, Action<IProjectBuildState> stateChangedCallback)
        {
            var readyToBuildState = _projectBuildStateFactory.CreateReadyToBuildState();
            await readyToBuildState.StartBuildingAsync(filePath, stateChangedCallback);
        }
    }
}