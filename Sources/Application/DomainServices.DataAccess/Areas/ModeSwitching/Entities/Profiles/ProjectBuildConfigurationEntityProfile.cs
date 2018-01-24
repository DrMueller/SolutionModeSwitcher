using AutoMapper;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class ProjectBuildConfigurationEntityProfile : Profile
    {
        public ProjectBuildConfigurationEntityProfile()
        {
            CreateMap<ProjectBuildConfiguration, ProjectBuildConfigurationEntity>()
                .ForMember(d => d.ConfigurationName, c => c.MapFrom(f => f.ConfigurationName))
                .ForMember(d => d.OutputPath, c => c.MapFrom(f => f.OutputPath))
                .ForMember(d => d.PlatformName, c => c.MapFrom(f => f.PlatformName))
                .ForMember(d => d.PlatformTarget, c => c.MapFrom(f => f.PlatformTarget));

            CreateMap<ProjectBuildConfigurationEntity, ProjectBuildConfiguration>()
                .ConvertUsing(
                    dto =>
                    {
                        var result = new ProjectBuildConfiguration(
                            dto.ConfigurationName,
                            dto.PlatformName,
                            dto.PlatformTarget,
                            dto.OutputPath);

                        return result;
                    });
        }
    }
}