using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Dtos;

namespace Mmu.Sms.WpfUI.Areas.Configuration.Services.Handlers.Implementation
{
    public class SelectProjectDtoMappingHandler : ISelectProjectDtoMappingHandler
    {
        public IReadOnlyCollection<SelectProjectDto> Map(IReadOnlyCollection<ProjectReferenceConfigurationDto> dtos, SolutionModeConfigurationDto configuration)
        {
            var result = new List<SelectProjectDto>();

            foreach (var referenceConfigurationDto in dtos)
            {
                var existsInConfig = configuration.ProjectReferenceConfigurations.Any(f => f.AssemblyName == referenceConfigurationDto.AssemblyName);
                var selectProjectDto = new SelectProjectDto
                {
                    AssemblyName = referenceConfigurationDto.AssemblyName,
                    IsSelected = existsInConfig,
                    AbsoluteProjectFilePath = referenceConfigurationDto.AbsoluteProjectFilePath
                };

                result.Add(selectProjectDto);
            }

            return result;
        }
    }
}