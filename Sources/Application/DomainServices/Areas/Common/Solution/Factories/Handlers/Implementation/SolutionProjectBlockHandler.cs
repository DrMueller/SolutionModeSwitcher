using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Models;
using Mmu.Sms.DomainServices.Infrastructure.StringParsing;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Handlers.Implementation
{
    public class SolutionProjectBlockHandler : ISolutionProjectBlockHandler
    {
        private readonly IFileProxy _fileProxy;
        private readonly IStringParsingService _stringParsingService;
        private IReadOnlyCollection<SolutionProjectBlock> _solutionProjectBlocks;

        public SolutionProjectBlockHandler(IStringParsingService stringParsingService, IFileProxy fileProxy)
        {
            _stringParsingService = stringParsingService;
            _fileProxy = fileProxy;
        }

        public SolutionProjectBlock FindBlock(string assemblyName)
        {
            return _solutionProjectBlocks.First(f => f.AssemblyName == assemblyName);
        }

        public IReadOnlyCollection<SolutionProjectBlock> GetAllBlocks()
        {
            return _solutionProjectBlocks;
        }

        public void Initialize(string solutionPath)
        {
            var solutionConfigData = _fileProxy.ReadAllText(solutionPath);
            var projectBlockStrings = _stringParsingService.GetBlockElements(
                solutionConfigData,
                SolutionConfigConstants.ProjectStartTagName,
                SolutionConfigConstants.ProjectEndTagName);

            _solutionProjectBlocks = projectBlockStrings.Select(str => new SolutionProjectBlock(str)).ToList();
        }
    }
}