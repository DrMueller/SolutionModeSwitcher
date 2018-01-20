using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities
{
    public class SolutionConfigurationFileEntity
    {
        public string FilePath { get; set; }
        public SolutionProjectReferencesEntity SolutionProjectReferences { get; set; }
    }
}