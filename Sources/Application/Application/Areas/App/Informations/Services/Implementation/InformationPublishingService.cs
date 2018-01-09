using Mmu.Sms.Application.Areas.App.Informations.Models;

namespace Mmu.Sms.Application.Areas.App.Informations.Services.Implementation
{
    public class InformationPublishingService : IInformationPublishingService
    {
        private readonly IInformationConfigurationService _informationConfigurationService;

        public InformationPublishingService(IInformationConfigurationService informationConfigurationService)
        {
            _informationConfigurationService = informationConfigurationService;
        }

        public void Publish(InformationType informationType, string informationText)
        {
            var information = new Information(informationType, informationText);
            var callbacks = _informationConfigurationService.GetRegisteredCallbacks(informationType);

            foreach (var cb in callbacks)
            {
                cb(information);
            }
        }
    }
}