using System.Linq;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.Configuration.Factories.Implementation;

namespace Mmu.Sms.Application.Areas.Domain.Confguration.Dtos.Profiles
{
    public class SolutionModeConfigurationDtoProfile : Profile
    {
        public SolutionModeConfigurationDtoProfile()
        {
            CreateMap<SolutionModeConfigurationDto, SolutionModeConfiguration>()
                .ConvertUsing(
                    dto =>
                    {
                        var modeFactory = ProvisioningServiceSingleton.Instance.GetService<SolutionModeConfigurationFactory>();
                        var rerferenceConfigs = dto.ProjectReferenceConfigurations.Select(f => new ProjectReferenceConfiguration(f.ProjectName, f.AbsoluteProjectFilePath)).ToList();
                        var result = modeFactory.Create(dto.Id, dto.ConfigurationName, dto.SolutionFilePath, rerferenceConfigs);
                        return result;
                    });

            CreateMap<SolutionModeConfiguration, SolutionModeConfigurationDto>()
                .ForMember(d => d.ConfigurationName, c => c.MapFrom(f => f.ConfigurationName))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.ProjectReferenceConfigurations, c => c.MapFrom(f => f.ProjectReferenceConfigurations))
                .ForMember(d => d.ProjectReferencesCount, c => c.Ignore())
                .ForMember(d => d.SolutionFilePath, c => c.MapFrom(f => f.SolutionFilePath));
        }
    }
}