using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class ProjectConfigurationFileEntityProfile : Profile
    {
        public ProjectConfigurationFileEntityProfile()
        {
            CreateMap<ProjectConfigurationFile, ProjectConfigurationFileEntity>()
                .ForMember(d => d.AssemblyReferences, c => c.MapFrom(f => f.AssemblyReferences))
                .ForMember(d => d.BuildConfigurations, c => c.MapFrom(f => f.BuildConfigurations))
                .ForMember(d => d.FilePath, c => c.MapFrom(f => f.FilePath))
                .ForMember(d => d.ProjectReferencs, c => c.MapFrom(f => f.ProjectReferences))
                .ForMember(d => d.PropertiesConfiguration, c => c.MapFrom(f => f.PropertiesConfiguration));

            CreateMap<ProjectConfigurationFileEntity, ProjectConfigurationFile>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var assemblyReferences = mapper.Map<List<ProjectAssemblyReference>>(dto.AssemblyReferences);
                        var projectReferences = mapper.Map<List<ProjectReference>>(dto.ProjectReferencs);
                        var propertiesConfiguration = mapper.Map<ProjectPropertiesConfiguration>(dto.PropertiesConfiguration);
                        var buildConfigurations = mapper.Map<List<ProjectBuildConfiguration>>(dto.BuildConfigurations);

                        var result = new ProjectConfigurationFile(
                            dto.FilePath,
                            assemblyReferences,
                            projectReferences,
                            propertiesConfiguration,
                            buildConfigurations);

                        return result;
                    });
        }
    }
}