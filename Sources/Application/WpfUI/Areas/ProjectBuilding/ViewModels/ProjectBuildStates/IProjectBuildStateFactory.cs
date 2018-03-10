using System;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates
{
    public interface IProjectBuildStateFactory
    {
        IProjectBuildState CreateBuildEnqueuedState();

        IProjectBuildState CreateBuildErrorState(Exception exception);

        IProjectBuildState CreateBuildInProgressState();

        IProjectBuildState CreateReadyToBuildState();
    }
}