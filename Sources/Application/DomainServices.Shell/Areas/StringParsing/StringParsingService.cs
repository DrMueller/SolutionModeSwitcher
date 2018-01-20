using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mmu.Sms.DomainServices.Infrastructure.StringParsing;

namespace Mmu.Sms.DomainServices.Shell.Areas.StringParsing
{
    public class StringParsingService : IStringParsingService
    {
        public IReadOnlyCollection<string> GetBlockElements(string data, string startValue, string endValue)
        {
            var result = new List<string>();
            var startIndex = data.IndexOf(startValue, StringComparison.Ordinal);

            while (startIndex > -1)
            {
                var endIndex = data.IndexOf(endValue, startIndex, StringComparison.Ordinal);
                if (endIndex == -1)
                {
                    endIndex = data.IndexOf("/>", startIndex, StringComparison.Ordinal);
                }

                var blockElement = data.Substring(startIndex, endIndex - startIndex + endValue.Length);
                result.Add(blockElement);
                startIndex = data.IndexOf(startValue, startIndex + 1, StringComparison.Ordinal);
            }

            return result;
        }

        public string GetValueBetween(string data, string startValue, string endValue)
        {
            var regex = new Regex($"({startValue})(?<groupToFind>.*)({endValue})", RegexOptions.Singleline);
            var regexMatch = regex.Match(data);
            if (!regexMatch.Success)
            {
                return string.Empty;
            }

            var refMatch = regexMatch.Groups["groupToFind"];
            return refMatch.Value;
        }
    }
}