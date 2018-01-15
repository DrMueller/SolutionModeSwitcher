using System.Linq;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Configuration;
using Mmu.Sms.DomainServices.Areas.Configuration.Factories.Implementation;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Configuration.Entities.Profiles
{
    public class SolutionModeConfigurationEntityProfile : Profile
    {
        public SolutionModeConfigurationEntityProfile()
        {
            CreateMap<SolutionModeConfiguration, SolutionModeConfigurationEntity>()
                .ForMember(d => d.ConfigurationName, c => c.MapFrom(f => f.ConfigurationName))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.ProjectReferenceConfigurations, c => c.MapFrom(f => f.ProjectReferenceConfigurations))
                .ForMember(d => d.ProjectReferencesCount, c => c.Ignore())
                .ForMember(d => d.SolutionFilePath, c => c.MapFrom(f => f.SolutionFilePath));

            CreateMap<SolutionModeConfigurationEntity, SolutionModeConfiguration>()
                .ConvertUsing(
                    entity =>
                    {
                        var modeFactory = ProvisioningServiceSingleton.Instance.GetService<SolutionModeConfigurationFactory>();
                        var rerferenceConfigs = entity.ProjectReferenceConfigurations.Select(f => new ProjectReferenceConfiguration(f.AssemblyName, f.AbsoluteProjectFilePath)).ToList();
                        var result = modeFactory.Create(entity.Id, entity.ConfigurationName, entity.SolutionFilePath, rerferenceConfigs);
                        return result;
                    });
        }
    }
}