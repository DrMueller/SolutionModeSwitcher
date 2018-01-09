using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionConfigurationFileFactory : ISolutionConfigurationFileFactory
    {
        private readonly ISolutionProjectReferencesFactory _solutionProjectReferencesFactory;

        public SolutionConfigurationFileFactory(ISolutionProjectReferencesFactory solutionProjectReferencesFactory)
        {
            _solutionProjectReferencesFactory = solutionProjectReferencesFactory;
        }

        public SolutionConfigurationFile Create(string filePath)
        {
            var solutionProjectReferences = _solutionProjectReferencesFactory.CreateFromSolutionFile(filePath);
            var result = new SolutionConfigurationFile(filePath, solutionProjectReferences);
            return result;
        }
    }
}