using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Common.Project.Factories;
using Mmu.Sms.Application.Areas.Domain.Common.Solution.Factories;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.ModeSwitching.Services;

namespace Mmu.Sms.Application.Areas.Domain.ModeSwitching.Services.Implementation
{
    public class SolutionSwitchingService : ISolutionSwitchingService
    {
        private readonly IFileProxy _fileProxy;
        private readonly IInformationPublishingService _informationPublishingService;
        private readonly IMapper _mapper;
        private readonly IProjectConfigurationDocumentFactory _projectConfigurationFileDocumentService;
        private readonly ISolutionConfigurationDataFactory _solutionConfigDataFactory;
        private readonly ISolutionModeSwitchingService _solutionModeSwitchingService;

        public SolutionSwitchingService(
            IInformationPublishingService informationPublishingService,
            ISolutionModeSwitchingService solutionModeSwitchingService,
            IProjectConfigurationDocumentFactory projectConfigurationFileDocumentService,
            ISolutionConfigurationDataFactory solutionConfigDataFactory,
            IFileProxy fileProxy,
            IMapper mapper)
        {
            _informationPublishingService = informationPublishingService;
            _solutionModeSwitchingService = solutionModeSwitchingService;
            _projectConfigurationFileDocumentService = projectConfigurationFileDocumentService;
            _solutionConfigDataFactory = solutionConfigDataFactory;
            _fileProxy = fileProxy;
            _mapper = mapper;
        }

        public void RevertSwitch(SolutionModeConfigurationDto configurationDto)
        {
            _informationPublishingService.Publish(InformationType.Important, "Starting to revert...");
            var configuration = _mapper.Map<SolutionModeConfiguration>(configurationDto);

            

            _informationPublishingService.Publish(InformationType.Success, "Finished!");
        }

        public void SwitchSolution(SolutionModeConfigurationDto configurationDto)
        {
            _informationPublishingService.Publish(InformationType.Important, "Starting to switch...");
            var configuration = _mapper.Map<SolutionModeConfiguration>(configurationDto);

            _informationPublishingService.Publish(InformationType.Info, "Switching it up...");
            var solutionSwitchResult = _solutionModeSwitchingService.SwitchSolutionMode(configuration);

            SaveSolutionToFile(solutionSwitchResult.SwitchedSolutionConfigFile);
            SaveProjectsToFiles(solutionSwitchResult.SwitchedProjectConfigFiles);

            _informationPublishingService.Publish(InformationType.Success, "Finished!");
        }

        private void SaveProjectsToFiles(IEnumerable<ProjectConfigurationFile> projectConfigFiles)
        {
            foreach (var projectConfigFile in projectConfigFiles)
            {
                var doc = _projectConfigurationFileDocumentService.CreateDocument(projectConfigFile);
                _informationPublishingService.Publish(InformationType.Info, $"Saving Project to {projectConfigFile.FilePath}...");
                doc.Save(projectConfigFile.FilePath);
            }
        }

        private void SaveSolutionToFile(SolutionConfigurationFile solutionConfigFile)
        {
            var solutionConfigData = _solutionConfigDataFactory.CreateSolutionConfigurationData(solutionConfigFile);
            _informationPublishingService.Publish(InformationType.Info, $"Saving Solution to {solutionConfigFile.FilePath}...");
            _fileProxy.WriteAllText(solutionConfigFile.FilePath, solutionConfigData);
        }
    }
}