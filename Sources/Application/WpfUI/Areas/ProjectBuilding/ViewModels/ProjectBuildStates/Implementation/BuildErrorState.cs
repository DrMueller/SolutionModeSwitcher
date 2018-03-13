using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.Implementation
{
    public class BuildErrorState : IProjectBuildState
    {
        private readonly Exception _exception;

        public BuildErrorState(Exception exception)
        {
            _exception = exception;
        }

        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Exclamation_Red.png";
        public bool IsBuildInProgress => false;
        public bool IsTooltipVisible => true;
        public string TooltipText => _exception.Message;

        // We can retry from a error state 
        public async Task StartBuildingAsync(string filePath, Func<string, Task> buildRequestedCallback, Action<IProjectBuildState> stateChangedCallback)
        {
            var readyToBuildState = new ReadyToBuildState();
            await readyToBuildState.StartBuildingAsync(filePath, buildRequestedCallback, stateChangedCallback);
        }
    }
}