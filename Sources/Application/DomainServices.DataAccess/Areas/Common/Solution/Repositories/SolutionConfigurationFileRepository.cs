using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories
{
    public class SolutionConfigurationFileRepository : ISolutionConfigurationFileRepository
    {
        private readonly IFileProxy _fileProxy;
        private readonly ISolutionConfigurationDataFactory _solutionConfigurationDataFactory;
        private readonly ISolutionProjectReferencesFactory _solutionProjectReferencesRepository;

        public SolutionConfigurationFileRepository(
            ISolutionProjectReferencesFactory solutionProjectReferencesRepository,
            ISolutionConfigurationDataFactory solutionConfigurationDataFactory,
            IFileProxy fileProxy)
        {
            _solutionProjectReferencesRepository = solutionProjectReferencesRepository;
            _solutionConfigurationDataFactory = solutionConfigurationDataFactory;
            _fileProxy = fileProxy;
        }

        public SolutionConfigurationFile Load(string filePath)
        {
            var solutionProjectReferences = _solutionProjectReferencesRepository.Create(filePath);
            var result = new SolutionConfigurationFile(filePath, solutionProjectReferences);

            return result;
        }

        public void Save(SolutionConfigurationFile solutionConfigFile)
        {
            var configData = _solutionConfigurationDataFactory.CreateSolutionConfigurationData(solutionConfigFile);
            _fileProxy.WriteAllText(solutionConfigFile.FilePath, configData);
        }
    }
}