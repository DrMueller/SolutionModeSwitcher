using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToSolutionPropertiesAdapter : IStringToSolutionPropertiesAdapter
    {
        public SolutionProperties Adapt(List<string> solutionDataLines)
        {
            var dataLinesList = solutionDataLines.ToList();

            var startLineIndex = dataLinesList.FindIndex(f => f.Contains("GlobalSection(SolutionProperties) = preSolution"));
            var hideSolutioNodeValue = dataLinesList.ElementAt(startLineIndex + 1);
            hideSolutioNodeValue = hideSolutioNodeValue.Replace("HideSolutionNode = ", string.Empty);
            hideSolutioNodeValue = hideSolutioNodeValue.Trim();
            var hideSolutionNode = bool.Parse(hideSolutioNodeValue);
            var result = new SolutionProperties(hideSolutionNode);

            return result;
        }
    }
}