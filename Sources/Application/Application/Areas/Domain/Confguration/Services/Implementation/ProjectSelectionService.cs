using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Services.Implementation
{
    public class ProjectSelectionService : IProjectSelectionService
    {
        private readonly IMapper _mapper;
        private readonly ISolutionConfigurationFileFactory _solutionConfigurationFileFactory;

        public ProjectSelectionService(ISolutionConfigurationFileFactory solutionConfigurationFileFactory, IMapper mapper)
        {
            _solutionConfigurationFileFactory = solutionConfigurationFileFactory;
            _mapper = mapper;
        }

        public IReadOnlyCollection<ProjectReferenceConfigurationDto> LoadProjects(string solutionFilePath)
        {
            var solutionConfig = _solutionConfigurationFileFactory.Create(solutionFilePath);
            var result = _mapper.Map<List<ProjectReferenceConfigurationDto>>(solutionConfig.SolutionProjectReferences.Entries);
            return result;
        }
    }
}