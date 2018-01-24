using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToSolutionProjectConfigurationAdapter : IStringToSolutionProjectConfigurationAdapter
    {
        public IReadOnlyCollection<SolutionProjectConfiguration> Adapt(string projectGuid, List<string> solutionDataLines)
        {
            var configLineStart = projectGuid + ".";
            var relevantLines = solutionDataLines.Where(f => f.Contains(configLineStart));
            var result = relevantLines.Select(ParseLine).ToList();

            return result;
        }

        private static SolutionProjectConfiguration ParseLine(string configLine)
        {
            // {57CB554C-0C85-4009-B7E8-092EAC683420}.Production|Any CPU.ActiveCfg = Release|Any CPU
            // {990FCE27-577E-4DFC-9523-9A293AFD83C2}.Release|Any CPU.Build.0 = Debug|Any CPU
            var splitted = configLine.Split('.');
            var configKey = splitted[1];
            var configDescription = splitted[2];

            if (splitted.Length == 4)
            {
                configDescription += "." + splitted[3];
            }

            var result = new SolutionProjectConfiguration(configKey, configDescription);
            return result;
        }
    }
}