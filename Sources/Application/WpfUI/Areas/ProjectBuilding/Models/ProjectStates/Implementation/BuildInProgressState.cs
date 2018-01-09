using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models.ProjectStates.Implementation
{
    public class BuildInProgressState : IProjectBuildState
    {
        public string ImageSource => "/Mmu.Sms.WpfUI;component/Assets/FA_Cog_Green.png";
        public bool IsBuildInProgress => true;
        public bool IsTooltipVisible => false;
        public string TooltipText => string.Empty;

        public Task StartBuildingAsync(string filePath, Func<string, Task> buildRequestedCallback, Action<IProjectBuildState> stateChangedCallback)
        {
            // Nothing to do, since it's already building
            return Task.FromResult<object>(null);
        }
    }
}