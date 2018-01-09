using AutoMapper;
using Mmu.Sms.Domain.Areas.Configuration;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Dtos.Profiles
{
    public class ProjectReferenceConfigurationDtoProfile : Profile
    {
        public ProjectReferenceConfigurationDtoProfile()
        {
            CreateMap<ProjectReferenceConfigurationDto, ProjectReferenceConfiguration>()
                .ConvertUsing(
                    dto => new ProjectReferenceConfiguration(dto.AssemblyName, dto.AbsoluteProjectFilePath));

            CreateMap<ProjectReferenceConfiguration, ProjectReferenceConfigurationDto>()
                .ForMember(d => d.AssemblyName, c => c.MapFrom(f => f.AssemblyName))
                .ForMember(d => d.AbsoluteProjectFilePath, c => c.MapFrom(f => f.AbsoluteProjectFilePath));
        }
    }
}