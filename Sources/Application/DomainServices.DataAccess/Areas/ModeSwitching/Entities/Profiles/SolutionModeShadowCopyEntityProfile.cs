using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.ModeSwitching;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class SolutionModeShadowCopyEntityProfile : Profile
    {
        public SolutionModeShadowCopyEntityProfile()
        {
            CreateMap<SolutionModeShadowCopy, SolutionModeShadowCopyEntity>()
                .ForMember(d => d.ConfigurationId, c => c.MapFrom(f => f.ConfigurationId))
                .ForMember(d => d.ProjectConfigurationFiles, c => c.MapFrom(f => f.ProjectConfigFiles))
                .ForMember(d => d.SolutionConfigurationFile, c => c.MapFrom(f => f.SolutionConfigFile));

            CreateMap<SolutionModeShadowCopyEntity, SolutionModeShadowCopy>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var solutionConfigFile = mapper.Map<SolutionConfigurationFile>(dto.SolutionConfigurationFile);
                        var projectConfigFiles = mapper.Map<List<ProjectConfigurationFile>>(dto.ProjectConfigurationFiles);

                        var result = new SolutionModeShadowCopy(
                            dto.ConfigurationId,
                            solutionConfigFile,
                            projectConfigFiles);

                        return result;
                    });
        }
    }
}