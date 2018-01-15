using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionConfigurationDataFactory : ISolutionConfigurationDataFactory
    {
        private readonly IFileProxy _fileProxy;
        private readonly ISolutionProjectBlockFactory _solutionProjectBlockFactory;

        public SolutionConfigurationDataFactory(ISolutionProjectBlockFactory solutionProjectBlockFactory, IFileProxy fileProxy)
        {
            _solutionProjectBlockFactory = solutionProjectBlockFactory;
            _fileProxy = fileProxy;
        }

        public string CreateSolutionConfigurationData(SolutionConfigurationFile solutionConfigFile)
        {
            var solutionConfigData = _fileProxy.ReadAllText(solutionConfigFile.FilePath);
            _solutionProjectBlockFactory.Initialize(solutionConfigFile.FilePath);

            var allBlocksInFile = _solutionProjectBlockFactory.GetAllBlocks();

            foreach (var blockInFile in allBlocksInFile)
            {
                if (!solutionConfigFile.CheckIfContainsReference(blockInFile.AssemblyName))
                {
                    solutionConfigData = solutionConfigData.Replace(blockInFile.Data, string.Empty);
                }
            }

            return solutionConfigData;
        }
    }
}