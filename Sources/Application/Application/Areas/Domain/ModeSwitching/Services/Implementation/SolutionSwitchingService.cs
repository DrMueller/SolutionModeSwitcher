using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.Common.Project.Repositories;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Services;

namespace Mmu.Sms.Application.Areas.Domain.ModeSwitching.Services.Implementation
{
    public class SolutionSwitchingService : ISolutionSwitchingService
    {
        private readonly IInformationPublishingService _informationPublishingService;
        private readonly IMapper _mapper;
        private readonly IProjectConfigurationFileRepository _projectConfigurationFileRepository;
        private readonly ISolutionConfigurationFileRepository _solutionConfigFileRepository;
        private readonly ISolutionModeRevertingService _solutionModeRevertingService;
        private readonly ISolutionModeSwitchingService _solutionModeSwitchingService;

        public SolutionSwitchingService(
            IInformationPublishingService informationPublishingService,
            ISolutionModeSwitchingService solutionModeSwitchingService,
            ISolutionModeRevertingService solutionModeRevertingService,
            ISolutionConfigurationFileRepository solutionConfigFileRepository,
            IProjectConfigurationFileRepository projectConfigurationFileRepository,
            IMapper mapper)
        {
            _informationPublishingService = informationPublishingService;
            _solutionModeSwitchingService = solutionModeSwitchingService;
            _solutionModeRevertingService = solutionModeRevertingService;
            _solutionConfigFileRepository = solutionConfigFileRepository;
            _projectConfigurationFileRepository = projectConfigurationFileRepository;
            _mapper = mapper;
        }

        public void RevertSwitch(SolutionModeConfigurationDto configurationDto)
        {
            _informationPublishingService.Publish(InformationType.Important, "Starting to revert...");
            var configuration = _mapper.Map<SolutionModeConfiguration>(configurationDto);
            _solutionModeRevertingService.RevertSolutionMode(configuration);
            _informationPublishingService.Publish(InformationType.Success, "Finished!");
        }

        public void SwitchSolution(SolutionModeConfigurationDto configurationDto)
        {
            _informationPublishingService.Publish(InformationType.Important, "Starting to switch...");
            var configuration = _mapper.Map<SolutionModeConfiguration>(configurationDto);

            _informationPublishingService.Publish(InformationType.Info, "Switching it up...");
            var solutionSwitchResult = _solutionModeSwitchingService.SwitchSolutionMode(configuration);

            _informationPublishingService.Publish(InformationType.Info, $"Saving Solution to {solutionSwitchResult.SwitchedSolutionConfigFile.FilePath}...");
            _solutionConfigFileRepository.Save(solutionSwitchResult.SwitchedSolutionConfigFile);

            SaveProjectsToFiles(solutionSwitchResult.SwitchedProjectConfigFiles);
            _informationPublishingService.Publish(InformationType.Success, "Finished!");
        }

        private void SaveProjectsToFiles(IEnumerable<ProjectConfigurationFile> projectConfigFiles)
        {
            foreach (var projectConfigFile in projectConfigFiles)
            {
                _informationPublishingService.Publish(InformationType.Info, $"Saving Project to {projectConfigFile.FilePath}...");
                _projectConfigurationFileRepository.Save(projectConfigFile);
            }
        }
    }
}