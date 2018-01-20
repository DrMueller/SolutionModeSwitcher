using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class GlobalSectionBlockFactory : IGlobalSectionBlockFactory
    {
        public IReadOnlyCollection<GlobalSectionBlock> CreateGlobalSectionBlocks(string solutionConfigurationData)
        {
            var result = new List<GlobalSectionBlock>();

            var data = solutionConfigurationData;
            var lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var withinGlobalEntryBlock = false;
            List<SectionEntryBlock> sectionEntries = null;

            foreach (var line in lines)
            {
                if (line.Contains("EndGlobalSection"))
                {
                    result.Add(new GlobalSectionBlock(sectionEntries));
                    withinGlobalEntryBlock = false;
                    continue;
                }

                if (line.Contains("GlobalSection"))
                {
                    sectionEntries = new List<SectionEntryBlock>();
                    withinGlobalEntryBlock = true;
                    continue;
                }

                if (withinGlobalEntryBlock)
                {
                    sectionEntries.Add(new SectionEntryBlock(line));
                }
            }

            return result;
        }
    }
}