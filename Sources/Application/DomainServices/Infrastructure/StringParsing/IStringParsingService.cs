using System.Collections.Generic;

namespace Mmu.Sms.DomainServices.Infrastructure.StringParsing
{
    public interface IStringParsingService
    {
        IReadOnlyCollection<string> GetBlockElements(string data, string startValue, string endValue);

        string GetValueBetween(string data, string startValue, string endValue);
    }
}