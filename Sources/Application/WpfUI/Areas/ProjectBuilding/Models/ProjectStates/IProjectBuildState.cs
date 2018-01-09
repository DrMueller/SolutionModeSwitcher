using System;
using System.Threading.Tasks;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models.ProjectStates
{
    public interface IProjectBuildState
    {
        string ImageSource { get; }
        bool IsBuildInProgress { get; }
        bool IsTooltipVisible { get; }
        string TooltipText { get; }

        Task StartBuildingAsync(
            string filePath,
            Func<string, Task> buildRequestedCallback,
            Action<IProjectBuildState> stateChangedCallback);
    }
}