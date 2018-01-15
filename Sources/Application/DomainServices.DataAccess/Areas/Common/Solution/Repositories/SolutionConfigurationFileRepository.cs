using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories.Handlers;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories
{
    public class SolutionConfigurationFileRepository : ISolutionConfigurationFileRepository
    {
        private readonly ISolutionProjectReferencesRepository _solutionProjectReferencesRepository;

        public SolutionConfigurationFileRepository(ISolutionProjectReferencesRepository solutionProjectReferencesRepository)
        {
            _solutionProjectReferencesRepository = solutionProjectReferencesRepository;
        }

        public SolutionConfigurationFile Load(string filePath)
        {
            var solutionProjectReferences = _solutionProjectReferencesRepository.Load(filePath);
            var result = new SolutionConfigurationFile(filePath, solutionProjectReferences);

            return result;
        }

        public void Save(SolutionConfigurationFile solutionConfigFile)
        {
            throw new System.NotImplementedException();
        }
    }
}