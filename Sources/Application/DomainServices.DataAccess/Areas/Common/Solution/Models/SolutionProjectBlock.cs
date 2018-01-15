using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models
{
    public class SolutionProjectBlock
    {
        private readonly Regex _regex = new Regex("(}\"\\) = \")(?<groupToFind>.*)(\", \")");

        public SolutionProjectBlock(string data)
        {
            Data = data;
        }

        public string AssemblyName
        {
            get
            {
                var regexMatch = _regex.Match(Data);
                if (!regexMatch.Success)
                {
                    return string.Empty;
                }

                var refMatch = regexMatch.Groups["groupToFind"].Value;

                // TODO: Why doesn't the RegEx work properly?
                if (refMatch.Contains(","))
                {
                    refMatch = refMatch.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).First().Replace("\"", string.Empty);
                }

                return refMatch;
            }
        }

        public string Data { get; }
    }
}