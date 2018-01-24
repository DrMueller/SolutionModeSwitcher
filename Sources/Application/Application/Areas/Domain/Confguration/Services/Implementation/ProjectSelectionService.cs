using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Repositories;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Services.Implementation
{
    public class ProjectSelectionService : IProjectSelectionService
    {
        private readonly IMapper _mapper;
        private readonly ISolutionConfigurationFileRepository _solutionConfigurationFileRepository;

        public ProjectSelectionService(ISolutionConfigurationFileRepository solutionConfigurationFileRepository, IMapper mapper)
        {
            _solutionConfigurationFileRepository = solutionConfigurationFileRepository;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProjectReferenceConfigurationDto> LoadProjects(string solutionFilePath)
        {
            var solutionConfig = _solutionConfigurationFileRepository.Load(solutionFilePath);
            ////var result = _mapper.Map<List<ProjectReferenceConfigurationDto>>(solutionConfig.SolutionProjectReferences.Entries);
            return null;
            ////return result;
        }
    }
}