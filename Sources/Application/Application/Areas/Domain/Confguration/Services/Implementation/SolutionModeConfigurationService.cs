using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.Configuration.Repositories;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Services.Implementation
{
    public class SolutionModeConfigurationService : ISolutionModeConfigurationService
    {
        private readonly IMapper _mapper;
        private readonly ISolutionModeConfigurationRepository _solutionModeConfigRepository;

        public SolutionModeConfigurationService(
            ISolutionModeConfigurationRepository solutionModeConfigRepository,
            IMapper mapper)
        {
            _solutionModeConfigRepository = solutionModeConfigRepository;
            _mapper = mapper;
        }

        public void DeleteConfiguration(string configurationId)
        {
            _solutionModeConfigRepository.Delete(configurationId);
        }

        public void Initialize(string configurationDirectory)
        {
            _solutionModeConfigRepository.Initialize(configurationDirectory);
        }

        public SolutionModeConfigurationDto Load(string configurationId)
        {
            var config = _solutionModeConfigRepository.Load(configurationId);
            var result = _mapper.Map<SolutionModeConfigurationDto>(config);
            return result;
        }

        public IReadOnlyCollection<SolutionModeConfigurationDto> LoadAll()
        {
            var configs = _solutionModeConfigRepository.LoadAll();
            var result = _mapper.Map<List<SolutionModeConfigurationDto>>(configs);
            return result;
        }

        public SolutionModeConfigurationDto SaveConfiguration(SolutionModeConfigurationDto configurationDto)
        {
            var config = _mapper.Map<SolutionModeConfiguration>(configurationDto);
            var returnedConfig = _solutionModeConfigRepository.Save(config);
            var result = _mapper.Map<SolutionModeConfigurationDto>(returnedConfig);
            return result;
        }
    }
}