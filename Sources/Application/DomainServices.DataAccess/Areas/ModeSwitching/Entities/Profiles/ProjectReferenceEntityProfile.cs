using AutoMapper;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class ProjectReferenceEntityProfile : Profile
    {
        public ProjectReferenceEntityProfile()
        {
            CreateMap<ProjectReference, ProjectReferenceEntity>()
                .ForMember(d => d.AssemblyName, c => c.MapFrom(f => f.AssemblyName))
                .ForMember(d => d.Guid, c => c.MapFrom(f => f.Guid))
                .ForMember(d => d.RelativeProjectFileIncludePath, c => c.MapFrom(f => f.RelativeProjectFileIncludePath));

            CreateMap<ProjectReferenceEntity, ProjectReference>()
                .ConvertUsing(
                    dto =>
                    {
                        var result = new ProjectReference(
                            dto.Guid,
                            dto.RelativeProjectFileIncludePath,
                            dto.AssemblyName);

                        return result;
                    });
        }
    }
}