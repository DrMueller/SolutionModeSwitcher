using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToGlobalExtensibilitiesAdapter : IStringToGlobalExtensibilitiesAdapter
    {
        public GlobalExtensibilities Adapt(List<string> solutionDataLines)
        {
            var dataLinesList = solutionDataLines.ToList();

            var startLineIndex = dataLinesList.FindIndex(f => f.Contains("GlobalSection(ExtensibilityGlobals) = postSolution"));
            var solutionGuidValue = dataLinesList.ElementAt(startLineIndex + 1);
            solutionGuidValue = solutionGuidValue.Replace("SolutionGuid = ", string.Empty);
            solutionGuidValue = solutionGuidValue.Trim();
            var result = new GlobalExtensibilities(solutionGuidValue);

            return result;
        }
    }
}