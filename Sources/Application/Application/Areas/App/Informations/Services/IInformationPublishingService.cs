using Mmu.Sms.Application.Areas.App.Informations.Models;

namespace Mmu.Sms.Application.Areas.App.Informations.Services
{
    public interface IInformationPublishingService
    {
        void Publish(InformationType informationType, string informationText);
    }
}