using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Factories
{
    public interface IBuildableProjectVmFactory
    {
        BuildableProjectViewModel Create();
    }
}