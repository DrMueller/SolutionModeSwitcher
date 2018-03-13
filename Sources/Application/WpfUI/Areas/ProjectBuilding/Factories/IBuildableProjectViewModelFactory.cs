using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Factories
{
    public interface IBuildableProjectViewModelFactory
    {
        BuildableProjectViewModel Create(string filePath);
    }
}