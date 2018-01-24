using AutoMapper;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class SolutionProjectConfigurationEntityProfile : Profile
    {
        public SolutionProjectConfigurationEntityProfile()
        {
            CreateMap<Domain.Areas.Common.Solution._legacy.SolutionProjectConfiguration, SolutionProjectConfigurationEntity>()
                .ForMember(d => d.ConfigurationName, c => c.MapFrom(f => f.ConfigurationName))
                .ForMember(d => d.FullName, c => c.MapFrom(f => f.FullName))
                .ForMember(d => d.IncludeInBuild, c => c.MapFrom(f => f.IncludeInBuild))
                .ForMember(d => d.Key, c => c.MapFrom(f => f.Key))
                .ForMember(d => d.PlatformName, c => c.MapFrom(f => f.PlatformName));

            CreateMap<SolutionProjectConfigurationEntity, Domain.Areas.Common.Solution._legacy.SolutionProjectConfiguration>()
                .ConvertUsing(
                    dto =>
                    {
                        var result = new Domain.Areas.Common.Solution._legacy.SolutionProjectConfiguration(
                            dto.Key,
                            dto.PlatformName,
                            dto.IncludeInBuild,
                            dto.FullName,
                            dto.ConfigurationName);

                        return result;
                    });
        }
    }
}