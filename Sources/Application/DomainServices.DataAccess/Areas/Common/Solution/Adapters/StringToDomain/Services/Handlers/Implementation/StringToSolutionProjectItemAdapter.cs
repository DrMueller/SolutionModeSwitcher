using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToSolutionProjectItemAdapter : IStringToSolutionProjectItemAdapter
    {
        public IReadOnlyCollection<SolutionProjectItem> Adapt(string projectGuid, List<string> solutionDataLines)
        {
            var currentLineIndex = solutionDataLines.FindIndex(f => f.Contains("Project(") && f.Contains(projectGuid));
            do
            {
                var currentLineValue = solutionDataLines.ElementAt(currentLineIndex);
                if (currentLineValue.Contains("EndProject"))
                {
                    break;
                }

                if (currentLineValue.Contains("(SolutionItems)"))
                {
                    return GetItemsFromLineIndex(currentLineIndex, solutionDataLines);
                }

                currentLineIndex++;
            } while (true);

            return new List<SolutionProjectItem>();
        }

        private static IReadOnlyCollection<SolutionProjectItem> GetItemsFromLineIndex(int currentLineIndex, IReadOnlyCollection<string> solutionDataLines)
        {
            // Move one down from the heading
            currentLineIndex++;
            var result = new List<SolutionProjectItem>();

            var currentLineValue = solutionDataLines.ElementAt(currentLineIndex);
            while (!currentLineValue.Contains("EndProjectSection"))
            {
                var itemPaths = currentLineValue.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                var leftItemPath = itemPaths[0].Trim();
                var rightItemPath = itemPaths[1].Trim();

                var solutionProjectItem = new SolutionProjectItem(leftItemPath, rightItemPath);
                result.Add(solutionProjectItem);

                currentLineValue = solutionDataLines.ElementAt(++currentLineIndex);
            }

            return result;
        }
    }
}