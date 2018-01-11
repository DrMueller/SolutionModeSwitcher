using AutoMapper;
using Mmu.Sms.Domain.Areas.ProjectBuilding;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Dtos.Profiles
{
    public class BuildableProjectDtoProfile : Profile
    {
        public BuildableProjectDtoProfile()
        {
            CreateMap<BuildableProject, BuildableProjectDto>()
                .ForMember(d => d.FilePath, c => c.MapFrom(f => f.FilePath));
        }
    }
}