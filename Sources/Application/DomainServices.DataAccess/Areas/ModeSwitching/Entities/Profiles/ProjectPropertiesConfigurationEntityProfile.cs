//using AutoMapper;
//using Mmu.Sms.Common.Ioc;
//using Mmu.Sms.Domain.Areas.Common.Project;
//using Mmu.Sms.Domain.Areas.Common._LegacyProject;

//namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
//{
//    public class ProjectPropertiesConfigurationEntityProfile : Profile
//    {
//        public ProjectPropertiesConfigurationEntityProfile()
//        {
//            CreateMap<ProjectPropertiesConfiguration, ProjectPropertiesConfigurationEntity>()
//                .ForMember(d => d.AssemblyName, c => c.MapFrom(f => f.AssemblyName))
//                .ForMember(d => d.OutputType, c => c.MapFrom(f => f.OutputType))
//                .ForMember(d => d.RootNamespace, c => c.MapFrom(f => f.RootNamespace));

//            CreateMap<ProjectPropertiesConfigurationEntity, ProjectPropertiesConfiguration>()
//                .ConvertUsing(
//                    dto =>
//                    {
//                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
//                        var outputType = mapper.Map<ProjectOutputType>(dto.OutputType);

//                        var result = new ProjectPropertiesConfiguration(
//                            dto.RootNamespace,
//                            dto.AssemblyName,
//                            outputType);

//                        return result;
//                    });
//        }
//    }
//}