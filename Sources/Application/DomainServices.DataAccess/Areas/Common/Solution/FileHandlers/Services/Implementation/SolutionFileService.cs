using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Services.Implementation
{
    public class SolutionFileService : ISolutionFileService
    {
        private readonly ISolutionBlockFactory _solutionBlockFactory;

        public SolutionFileService(ISolutionBlockFactory solutionBlockFactory)
        {
            _solutionBlockFactory = solutionBlockFactory;
        }

        public string RearrangeSolutionFile(SolutionConfigurationFile solutionConfigFile)
        {
            var solutionBlock = _solutionBlockFactory.Parse(solutionConfigFile.FilePath);

            AdjustEntries(solutionConfigFile, solutionBlock);

            var result = solutionBlock.CreateOutput();
            return result;
        }

        private static void AdjustEntries(SolutionConfigurationFile solutionConfigFile, SolutionBlock solutionBlock)
        {
            CheckRemoveBlocksByGuid(solutionConfigFile, solutionBlock.GlobalBlock.ProjectConfigPlatformsSectionBlock.ConfigurationBlocks);
            CheckRemoveBlocksByGuid(solutionConfigFile, solutionBlock.GlobalBlock.NestedProjectsSectionBlock.HierarchyEntryBlocks);
            CheckRemoveBlocksByGuid(solutionConfigFile, solutionBlock.ProjectBlocks);
        }

        private static void CheckRemoveBlocksByGuid<T>(SolutionConfigurationFile solutionConfigFile, ICollection<T> blocks)
            where T : IBlockWithGuid
        {
            var blocksToRemove = new List<T>();

            foreach (var block in blocks)
            {
                //if (solutionConfigFile.SolutionProjectReferences.Entries.All(f => f.Guid != block.Guid))
                //{
                //    blocksToRemove.Add(block);
                //}
            }

            foreach (var pro in blocksToRemove)
            {
                blocks.Remove(pro);
            }
        }
    }
}