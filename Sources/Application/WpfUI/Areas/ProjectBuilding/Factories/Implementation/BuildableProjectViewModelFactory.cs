using Mmu.Sms.Common.Ioc;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.Factories.Implementation
{
    public class BuildableProjectViewModelFactory : IBuildableProjectViewModelFactory
    {
        private readonly IProvisioningService _provisioningService;

        public BuildableProjectViewModelFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public BuildableProjectViewModel Create(string filePath)
        {
            var result = _provisioningService.GetService<BuildableProjectViewModel>();
            result.Initialize(filePath);

            return result;
        }
    }
}