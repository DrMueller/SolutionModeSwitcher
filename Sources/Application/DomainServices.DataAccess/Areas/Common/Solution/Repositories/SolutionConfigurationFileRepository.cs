using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories
{
    public class SolutionConfigurationFileRepository : ISolutionConfigurationFileRepository
    {
        private readonly IFileProxy _fileProxy;
        private readonly ISolutionConfigurationFileToStringAdapter _solutionConfigToStringAdapter;
        private readonly IStringToSolutionConfigurationFileAdapter _stringToSolutionConfigAdapter;

        public SolutionConfigurationFileRepository(
            ISolutionConfigurationFileToStringAdapter solutionConfigToStringAdapter,
            IStringToSolutionConfigurationFileAdapter stringToSolutionConfigAdapter,
            IFileProxy fileProxy)
        {
            _solutionConfigToStringAdapter = solutionConfigToStringAdapter;
            _stringToSolutionConfigAdapter = stringToSolutionConfigAdapter;
            _fileProxy = fileProxy;
        }

        public SolutionConfigurationFile Load(string filePath)
        {
            var result = _stringToSolutionConfigAdapter.Adapt(filePath);
            return result;
        }

        public void Save(SolutionConfigurationFile solutionConfigFile)
        {
            var solutionConfigData = _solutionConfigToStringAdapter.Adapt(solutionConfigFile);
            _fileProxy.WriteAllText(solutionConfigFile.FilePath, solutionConfigData);
        }
    }
}