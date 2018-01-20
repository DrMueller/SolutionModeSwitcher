using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.DeepCopy;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.ModeSwitching;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Repositories;

namespace Mmu.Sms.DomainServices.Areas.ModeSwitching.Services.Handlers.Implementation
{
    public class SolutionModeShadowCopyCollector : ISolutionModeShadowCopyCollector
    {
        private readonly IDeepCopyService _deepCopyService;
        private readonly ISolutionModeShadowCopyRepository _solutionModeShadowCopyRepository;
        private string _configurationId;
        private List<ProjectConfigurationFile> _projectConfigFileCopies;
        private SolutionConfigurationFile _solutionConfigFileCopy;

        public SolutionModeShadowCopyCollector(ISolutionModeShadowCopyRepository solutionModeShadowCopyRepository, IDeepCopyService deepCopyService)
        {
            _solutionModeShadowCopyRepository = solutionModeShadowCopyRepository;
            _deepCopyService = deepCopyService;
        }

        public void AddProjectConfigurationFileCopy(ProjectConfigurationFile projectConfigFile)
        {
            var projectConfigFileCopy = _deepCopyService.DeepCopy(projectConfigFile);
            _projectConfigFileCopies.Add(projectConfigFileCopy);
        }

        public void Initialize(string configurationId)
        {
            _configurationId = configurationId;
            _projectConfigFileCopies = new List<ProjectConfigurationFile>();
        }

        public void Save()
        {
            var shadowCopy = new SolutionModeShadowCopy(_configurationId, _solutionConfigFileCopy, _projectConfigFileCopies);
            _solutionModeShadowCopyRepository.Save(shadowCopy);
        }

        public void SetSolutionConfigurationFileCopy(SolutionConfigurationFile solutionConfigFile)
        {
            _solutionConfigFileCopy = _deepCopyService.DeepCopy(solutionConfigFile);
        }
    }
}