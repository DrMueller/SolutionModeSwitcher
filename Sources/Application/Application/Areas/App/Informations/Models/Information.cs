using System;

namespace Mmu.Sms.Application.Areas.App.Informations.Models
{
    public class Information
    {
        public Information(InformationType informationType, string informationText)
        {
            InformationType = informationType;
            InformationText = informationText;
            TimeStampDescription = DateTime.Now.ToString("g");
        }

        public string InformationText { get; }
        public InformationType InformationType { get; }
        public string TimeStampDescription { get; }
    }
}