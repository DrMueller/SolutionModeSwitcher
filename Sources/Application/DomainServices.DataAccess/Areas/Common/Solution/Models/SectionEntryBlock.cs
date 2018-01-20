using System;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models
{
    public class SectionEntryBlock
    {
        public SectionEntryBlock(string data)
        {
            Guard.StringNotNullOrEmpty(() => data);
            Data = data;
        }

        public string Data { get; }

        public string ParseGuid()
        {
            // {8560F780-A8E0-43A0-B49A-EBD0D10C0E88} = {97D93079-E9CB-45BC-B8E4-FD6C86031261} --> Left is the right one
            // {21F1F78E-700F-4111-9136-2D9C1BFFF626}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
            // No GUID

            var startIndex = Data.IndexOf("{", StringComparison.OrdinalIgnoreCase);
            var endIndex = Data.IndexOf("}", StringComparison.OrdinalIgnoreCase);

            if (startIndex == -1 || endIndex == -1)
            {
                return string.Empty;
            }

            var guid = Data.Substring(startIndex, endIndex - (startIndex -1));
            return guid;
        }
    }
}