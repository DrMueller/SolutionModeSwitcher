using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models.ProjectStates.Implementation
{
    public class ReadyToBuildState : IProjectBuildState
    {
        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Cog_Green.png";
        public bool IsBuildInProgress => false;
        public bool IsTooltipVisible => false;
        public string TooltipText => string.Empty;

        public async Task StartBuildingAsync(
            string filePath,
            Func<string, Task> buildRequestedCallback,
            Action<IProjectBuildState> stateChangedCallback)
        {
            try
            {
                stateChangedCallback(new BuildInProgressState());
                await buildRequestedCallback(filePath);
                stateChangedCallback(new ReadyToBuildState());
            }
            catch (Exception ex)
            {
                stateChangedCallback(new BuildErrorState(ex));
            }
        }
    }
}