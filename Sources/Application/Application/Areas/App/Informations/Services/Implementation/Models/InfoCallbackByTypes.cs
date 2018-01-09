using System;
using System.Collections.Generic;
using Mmu.Sms.Application.Areas.App.Informations.Models;

namespace Mmu.Sms.Application.Areas.App.Informations.Services.Implementation.Models
{
    public class InfoCallbackByTypes
    {
        public InfoCallbackByTypes(Action<Information> informationCallback, IReadOnlyCollection<InformationType> relevantTypes)
        {
            InformationCallback = informationCallback;
            RelevantTypes = relevantTypes;
        }

        public Action<Information> InformationCallback { get; }
        public IReadOnlyCollection<InformationType> RelevantTypes { get; }
    }
}