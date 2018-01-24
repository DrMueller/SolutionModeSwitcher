using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class ProjectAssemblyReferenceEntityProfile : Profile
    {
        public ProjectAssemblyReferenceEntityProfile()
        {
            CreateMap<ProjectAssemblyReference, ProjectAssemblyReferenceEntity>()
                .ForMember(d => d.HintPath, c => c.MapFrom(f => f.HintPath))
                .ForMember(d => d.IncludeDefinition, c => c.MapFrom(f => f.IncludeDefinition))
                .ForMember(d => d.IsPrivate, c => c.MapFrom(f => f.IsPrivate))
                .ForMember(d => d.SpecificVersion, c => c.MapFrom(f => f.SpecificVersion));

            CreateMap<ProjectAssemblyReferenceEntity, ProjectAssemblyReference>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var includeDefinition = mapper.Map<IncludeDefinition>(dto.IncludeDefinition);
                        var result = new ProjectAssemblyReference(
                            includeDefinition,
                            dto.HintPath,
                            dto.IsPrivate,
                            dto.SpecificVersion);

                        return result;
                    });
        }
    }
}