using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class SolutionProjectReferencesEntityProfile : Profile
    {
        public SolutionProjectReferencesEntityProfile()
        {
            CreateMap<SolutionProjectReferences, SolutionProjectReferencesEntity>()
                .ForMember(d => d.Entries, c => c.MapFrom(f => f.Entries));

            CreateMap<SolutionProjectReferencesEntity, SolutionProjectReferences>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var projectReferences = mapper.Map<List<SolutionProjectReference>>(dto.Entries);

                        var result = new SolutionProjectReferences(projectReferences);
                        return result;
                    });
        }
    }
}