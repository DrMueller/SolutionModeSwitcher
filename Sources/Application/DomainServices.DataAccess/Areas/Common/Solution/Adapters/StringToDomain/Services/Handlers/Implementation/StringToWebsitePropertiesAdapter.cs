using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToWebsitePropertiesAdapter : IStringToWebsitePropertiesAdapter
    {
        public Maybe<WebsiteProperties> Adapt(string projectGuid, List<string> solutionDataLines)
        {
            var currentLineIndex = solutionDataLines.FindIndex(f => f.Contains("Project(") && f.Contains(projectGuid));
            do
            {
                var currentLineValue = solutionDataLines.ElementAt(currentLineIndex);
                if (currentLineValue.Contains("EndProject"))
                {
                    break;
                }

                if (currentLineValue.Contains("(WebsiteProperties)"))
                {
                    return GetWebsitePropertiesFromLineIndex(currentLineIndex, solutionDataLines);
                }

                currentLineIndex++;
            } while (true);

            return MaybeFactory.CreateNone<WebsiteProperties>();
        }

        private static Maybe<WebsiteProperties> GetWebsitePropertiesFromLineIndex(int currentLineIndex, List<string> solutionDataLines)
        {
            // Move one down from the heading
            currentLineIndex++;

            var lineValues = new List<string>();

            var currentLineValue = solutionDataLines.ElementAt(currentLineIndex);
            while (!currentLineValue.Contains("EndProjectSection"))
            {
                lineValues.Add(currentLineValue);
                currentLineValue = solutionDataLines.ElementAt(++currentLineIndex);
            }

            var data = string.Join(Environment.NewLine, lineValues);

            var websiteProperties = new WebsiteProperties(data);
            return MaybeFactory.CreateSome(websiteProperties);
        }
    }
}