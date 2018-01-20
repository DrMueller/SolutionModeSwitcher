using AutoMapper;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class ProjectOutputTypeEntityProfile : Profile
    {
        public ProjectOutputTypeEntityProfile()
        {
            CreateMap<ProjectOutputType, ProjectOutputTypeEntity>()
                .ForMember(d => d.FileExtension, c => c.MapFrom(f => f.FileExtension));

            CreateMap<ProjectOutputTypeEntity, ProjectOutputType>()
                .ConvertUsing(
                    dto =>
                    {
                        var result = new ProjectOutputType(
                            dto.FileExtension);

                        return result;
                    });
        }
    }
}