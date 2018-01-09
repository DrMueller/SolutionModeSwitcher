using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Dtos;
using Mmu.Sms.Domain.Areas.Configuration;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Services.Implementation
{
    public class ProjectSearchService : IProjectSearchService
    {
        private readonly IMapper _mapper;
        private readonly DomainServices.Areas.ProjectBuilding.Services.IProjectSearchService _projectSearchService;

        public ProjectSearchService(
            DomainServices.Areas.ProjectBuilding.Services.IProjectSearchService projectSearchService,
            IMapper mapper)
        {
            _projectSearchService = projectSearchService;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<BuildableProjectDto>> SearchProjectsAsync(SolutionModeConfigurationDto configurationDto)
        {
            var configuration = _mapper.Map<SolutionModeConfiguration>(configurationDto);
            var buildableProjects = await _projectSearchService.SearchProjectsAsync(configuration);

            var result = _mapper.Map<List<BuildableProjectDto>>(buildableProjects);
            return result;
        }
    }
}