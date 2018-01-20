using System.Collections.Generic;
using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class SolutionProjectReferenceEntityProfile : Profile
    {
        public SolutionProjectReferenceEntityProfile()
        {
            CreateMap<SolutionProjectReference, SolutionProjectReferenceEntity>()
                .ForMember(d => d.AbsoluteProjectFilePath, c => c.MapFrom(f => f.AbsoluteProjectFilePath))
                .ForMember(d => d.AssemblyName, c => c.MapFrom(f => f.AssemblyName))
                .ForMember(d => d.BlockText, c => c.MapFrom(f => f.BlockText))
                .ForMember(d => d.Guid, c => c.MapFrom(f => f.Guid));

            CreateMap<SolutionProjectReferenceEntity, SolutionProjectReference>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        var configurations = mapper.Map<List<SolutionProjectConfiguration>>(dto.Configurations);

                        var result = new SolutionProjectReference(
                            dto.BlockText,
                            dto.AssemblyName,
                            dto.Guid,
                            dto.ParentGuid,
                            dto.AbsoluteProjectFilePath,
                            configurations);

                        return result;
                    });
        }
    }
}