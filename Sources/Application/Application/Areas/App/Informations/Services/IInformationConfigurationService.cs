using System;
using System.Collections.Generic;
using Mmu.Sms.Application.Areas.App.Informations.Models;

namespace Mmu.Sms.Application.Areas.App.Informations.Services
{
    public interface IInformationConfigurationService
    {
        IReadOnlyCollection<Action<Information>> GetRegisteredCallbacks(InformationType informationType);

        void RegisterForAllTypes(Action<Information> informationCallback);

        void RegisterForTypes(Action<Information> informationCallback, params InformationType[] relevantTypes);
    }
}