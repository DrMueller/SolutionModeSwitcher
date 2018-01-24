using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Common.Solution._legacy;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Implementation
{
    public class SolutionModeRevertingService : ISolutionModeRevertingService
    {
        private readonly ISolutionModeShadowCopyRepository _shadowCopyRepository;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public SolutionModeRevertingService(
            ISolutionModeShadowCopyRepository shadowCopyRepository,
            ISolutionConfigurationFileRepository solutionConfigurationFileRepository)
        {
            _shadowCopyRepository = shadowCopyRepository;
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
        }

        public SolutionSwitchResult RevertSolutionMode(SolutionModeConfiguration configuration)
        {
            var shadowCopy = _shadowCopyRepository.Load(configuration.Id);
            var solutionConfigFile = _solutionConfigurationFileRepository.Load(configuration.SolutionFilePath);

            //MapSolutionProjectReferences(shadowCopy.SolutionConfigFile.SolutionProjectReferences, solutionConfigFile.SolutionProjectReferences);
            _solutionConfigurationFileRepository.Save(solutionConfigFile);
            return null;
        }

        private static void MapSolutionProjectReferences(SolutionProjectReferences shadowCopyReferences, SolutionProjectReferences solutionConfigFileReferences)
        {
            foreach (var shadowCopyReference in shadowCopyReferences.Entries)
            {
                if (solutionConfigFileReferences.Entries.All(f => f.AssemblyName != shadowCopyReference.AssemblyName))
                {
                    solutionConfigFileReferences.AddReferenceSorted(shadowCopyReference);
                }
            }

            var entriesToRemove = new List<SolutionProjectReference>();
            foreach (var solutionConfigReference in solutionConfigFileReferences.Entries)
            {
                if (shadowCopyReferences.Entries.All(f => f.AssemblyName != solutionConfigReference.AssemblyName))
                {
                    entriesToRemove.Add(solutionConfigReference);
                }
            }

            var entriesToRemoveAssemblyNames = entriesToRemove.Select(f => f.AssemblyName).ToList();
            solutionConfigFileReferences.RemoveReferences(entriesToRemoveAssemblyNames);
        }
    }
}