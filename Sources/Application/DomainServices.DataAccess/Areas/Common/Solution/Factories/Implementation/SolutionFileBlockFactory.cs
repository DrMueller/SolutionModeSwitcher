using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Models;
using Mmu.Sms.DomainServices.Infrastructure.StringParsing;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionFileBlockFactory : ISolutionFileBlockFactory
    {
        private readonly IFileProxy _fileProxy;
        private readonly IStringParsingService _stringParsingService;
        private readonly IGlobalSectionBlockFactory _globalSectionBlockFactory;
        private IReadOnlyCollection<SolutionProjectBlock> _projectBlocks;

        private IReadOnlyCollection<GlobalSectionBlock> _globalSectionBlocks;

        public SolutionFileBlockFactory(
            IStringParsingService stringParsingService,
            IGlobalSectionBlockFactory globalSectionBlockFactory,
            IFileProxy fileProxy)
        {
            _stringParsingService = stringParsingService;
            _globalSectionBlockFactory = globalSectionBlockFactory;
            _fileProxy = fileProxy;
        }

        public SolutionProjectBlock FindProjectBlock(string assemblyName)
        {
            return _projectBlocks.First(f => f.AssemblyName == assemblyName);
        }

        public IReadOnlyCollection<SolutionProjectBlock> CreateAllProjectBlocks()
        {
            return _projectBlocks;
        }

        public void Initialize(string solutionPath)
        {
            var solutionConfigData = _fileProxy.ReadAllText(solutionPath);
            InitializeProjectBlocks(solutionConfigData);
            InitializeGlobalSectionBlocks(solutionConfigData);
        }

        public IReadOnlyCollection<GlobalSectionBlock> CreateAllGlobalSectionBlocks()
        {
            return _globalSectionBlocks;
        }

        private void InitializeGlobalSectionBlocks(string solutionConfigData)
        {
            _globalSectionBlocks = _globalSectionBlockFactory.CreateGlobalSectionBlocks(solutionConfigData);
        }

        private void InitializeProjectBlocks(string solutionConfigData)
        {
            var projectBlockStrings = _stringParsingService.GetBlockElements(
                solutionConfigData,
                SolutionConfigConstants.ProjectStartTagName,
                SolutionConfigConstants.ProjectEndTagName);

            _projectBlocks = projectBlockStrings.Select(str => new SolutionProjectBlock(str)).ToList();
        }
    }
}