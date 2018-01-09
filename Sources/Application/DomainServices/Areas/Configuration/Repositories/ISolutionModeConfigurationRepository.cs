using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Configuration;

namespace Mmu.Sms.DomainServices.Areas.Configuration.Repositories
{
    public interface ISolutionModeConfigurationRepository
    {
        IReadOnlyCollection<SolutionModeConfiguration> LoadAll();

        SolutionModeConfiguration Save(SolutionModeConfiguration model);

        void Delete(string id);

        void Initialize(string configurationDirectory);

        SolutionModeConfiguration Load(string configurationId);
    }
}