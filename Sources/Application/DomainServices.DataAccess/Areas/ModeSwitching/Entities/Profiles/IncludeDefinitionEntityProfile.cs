using AutoMapper;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class IncludeDefinitionEntityProfile : Profile
    {
        public IncludeDefinitionEntityProfile()
        {
            CreateMap<IncludeDefinition, IncludeDefinitionEntity>()
                .ForMember(d => d.Culture, c => c.MapFrom(f => f.Culture))
                .ForMember(d => d.ProcessorArchitecture, c => c.MapFrom(f => f.ProcessorArchitecture))
                .ForMember(d => d.PublicKeyToken, c => c.MapFrom(f => f.PublicKeyToken))
                .ForMember(d => d.ShortName, c => c.MapFrom(f => f.ShortName))
                .ForMember(d => d.Version, c => c.MapFrom(f => f.Version));

            CreateMap<IncludeDefinitionEntity, IncludeDefinition>()
                .ConvertUsing(
                    dto =>
                    {
                        var result = new IncludeDefinition(
                            dto.ShortName,
                            dto.Version,
                            dto.Culture,
                            dto.PublicKeyToken,
                            dto.ProcessorArchitecture);
                        return result;
                    });
        }
    }
}