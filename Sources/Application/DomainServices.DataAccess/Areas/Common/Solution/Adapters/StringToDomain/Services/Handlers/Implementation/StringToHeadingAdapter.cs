using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToHeadingAdapter : IStringToHeadingAdapter
    {
        public SolutionHeadingElement Adapt(List<string> solutionDataLines)
        {
            var formatDescription = solutionDataLines.ElementAt(0);
            var visualStudioDescription = solutionDataLines.ElementAt(1);
            var visualStudioVersion = solutionDataLines.ElementAt(2);
            var minimalVisualStudioVersion = solutionDataLines.ElementAt(3);

            var result = new SolutionHeadingElement(formatDescription, visualStudioDescription, visualStudioVersion, minimalVisualStudioVersion);
            return result;
        }
    }
}