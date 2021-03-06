﻿using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Handlers;

namespace Mmu.Sms.Application.Areas.Domain.Common.Solution.Factories.Implementation
{
    public class SolutionConfigurationDataFactory : ISolutionConfigurationDataFactory
    {
        private readonly IFileProxy _fileProxy;
        private readonly ISolutionProjectBlockHandler _solutionProjectBlockHandler;

        public SolutionConfigurationDataFactory(ISolutionProjectBlockHandler solutionProjectBlockHandler, IFileProxy fileProxy)
        {
            _solutionProjectBlockHandler = solutionProjectBlockHandler;
            _fileProxy = fileProxy;
        }

        public string CreateSolutionConfigurationData(SolutionConfigurationFile solutionConfigFile)
        {
            var solutionConfigData = _fileProxy.ReadAllText(solutionConfigFile.FilePath);
            _solutionProjectBlockHandler.Initialize(solutionConfigFile.FilePath);

            var allBlocksInFile = _solutionProjectBlockHandler.GetAllBlocks();

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