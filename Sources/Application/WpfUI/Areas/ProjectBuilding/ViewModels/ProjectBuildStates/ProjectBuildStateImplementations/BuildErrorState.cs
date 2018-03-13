using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.ProjectBuildStateImplementations
{
    public class BuildErrorState : IProjectBuildState
    {
        private readonly IProjectBuildStateFactory _projectBuildStateFactory;
        private Exception _exception;

        public BuildErrorState(IProjectBuildStateFactory projectBuildStateFactory)
        {
            _projectBuildStateFactory = projectBuildStateFactory;
        }

        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Exclamation_Red.png";
        public bool IsBuildInProgress => false;
        public bool IsTooltipVisible => true;
        public string TooltipText => _exception.Message;

        public void Initialize(Exception exception)
        {
            _exception = exception;
        }

        public async Task StartBuildingAsync(string filePath, Action<IProjectBuildState> stateChangedCallback)
        {
            var readyToBuildState = _projectBuildStateFactory.CreateReadyToBuildState();
            await readyToBuildState.StartBuildingAsync(filePath, stateChangedCallback);
        }
    }
}