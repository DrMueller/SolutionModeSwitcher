using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services.Implementation.Models;

namespace Mmu.Sms.Application.Areas.App.Informations.Services.Implementation
{
    public class InformationConfigurationService : IInformationConfigurationService
    {
        private readonly List<InfoCallbackByTypes> _callbacksByTypes;

        public InformationConfigurationService()
        {
            _callbacksByTypes = new List<InfoCallbackByTypes>();
        }

        public IReadOnlyCollection<Action<Information>> GetRegisteredCallbacks(InformationType informationType)
        {
            var result = _callbacksByTypes.Where(f => f.RelevantTypes.Contains(informationType)).Select(f => f.InformationCallback).ToList();
            return result;
        }

        public void RegisterForAllTypes(Action<Information> informationCallback)
        {
            var allInfoTypes = Enum.GetValues(typeof(InformationType)).Cast<InformationType>().ToArray();
            RegisterForTypes(informationCallback, allInfoTypes);
        }

        public void RegisterForTypes(Action<Information> informationCallback, params InformationType[] relevantTypes)
        {
            var callbackByTypes = new InfoCallbackByTypes(informationCallback, relevantTypes);
            _callbacksByTypes.Add(callbackByTypes);
        }
    }
}