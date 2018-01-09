using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Handlers;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionConfigDataFactory : ISolutionConfigDataFactory
    {
        private readonly IFileProxy _fileProxy;
        private readonly ISolutionProjectBlockHandler _solutionProjectBlockHandler;

        public SolutionConfigDataFactory(ISolutionProjectBlockHandler solutionProjectBlockHandler, IFileProxy fileProxy)
        {
            _solutionProjectBlockHandler = solutionProjectBlockHandler;
            _fileProxy = fileProxy;
        }

        public string CreateSolutionConfigData(string solutionPath, SolutionConfigurationFile solutionConfig)
        {
            var solutionConfigData = _fileProxy.ReadAllText(solutionPath);
            _solutionProjectBlockHandler.Initialize(solutionPath);

            var allBlocksInFile = _solutionProjectBlockHandler.GetAllBlocks();

            foreach (var blockInFile in allBlocksInFile)
            {
                if (!solutionConfig.CheckIfContainsReference(blockInFile.AssemblyName))
                {
                    solutionConfigData = solutionConfigData.Replace(blockInFile.Data, string.Empty);
                }
            }

            return solutionConfigData;
        }
    }
}