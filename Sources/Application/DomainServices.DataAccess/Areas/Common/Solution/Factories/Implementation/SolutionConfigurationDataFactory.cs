//using System.Linq;
//using Mmu.Sms.Common.LanguageExtensions.Proxies;
//using Mmu.Sms.Domain.Areas.Common.Solution;

//namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
//{
//    public class SolutionConfigurationDataFactory : ISolutionConfigurationDataFactory
//    {
//        private readonly IFileProxy _fileProxy;
//        private readonly ISolutionFileBlockFactory _solutionProjectBlockFactory;

//        public SolutionConfigurationDataFactory(ISolutionFileBlockFactory solutionProjectBlockFactory, IFileProxy fileProxy)
//        {
//            _solutionProjectBlockFactory = solutionProjectBlockFactory;
//            _fileProxy = fileProxy;
//        }

//        public string CreateSolutionConfigurationData(SolutionConfigurationFile solutionConfigFile)
//        {
//            var solutionConfigData = _fileProxy.ReadAllText(solutionConfigFile.FilePath);
//            _solutionProjectBlockFactory.Initialize(solutionConfigFile.FilePath);

//            solutionConfigData = CheckRemoveProjectBlocks(solutionConfigData, solutionConfigFile);
//            solutionConfigData = CheckRemoveGlobalSectionEntries(solutionConfigData, solutionConfigFile);

//            return solutionConfigData;
//        }

//        private string CheckRemoveGlobalSectionEntries(string solutionConfigData, SolutionConfigurationFile solutionConfigFile)
//        {
//            var sectionEntryBlocks = _solutionProjectBlockFactory.CreateAllGlobalSectionBlocks().SelectMany(f => f.Blocks);

//            foreach (var block in sectionEntryBlocks)
//            {
//                var blockGuid = block.ParseGuid();
//                if (string.IsNullOrEmpty(blockGuid))
//                {
//                    // Non-Project entry
//                    continue;
//                }

//                if (solutionConfigFile.SolutionProjectReferences.Entries.All(f => f.Guid != blockGuid))
//                {
//                    solutionConfigData = solutionConfigData.Replace(block.Data, string.Empty);
//                }
//            }

//            return solutionConfigData;
//        }

//        private string CheckRemoveProjectBlocks(string solutionConfigData, SolutionConfigurationFile solutionConfigFile)
//        {
//            var projectBlocks = _solutionProjectBlockFactory.CreateAllProjectBlocks();

//            foreach (var projectBlock in projectBlocks)
//            {
//                if (solutionConfigFile.SolutionProjectReferences.Entries.All(f => f.AssemblyName != projectBlock.AssemblyName))
//                {
//                    solutionConfigData = solutionConfigData.Replace(projectBlock.Data, string.Empty);
//                }
//            }

//            return solutionConfigData;
//        }
//    }
//}