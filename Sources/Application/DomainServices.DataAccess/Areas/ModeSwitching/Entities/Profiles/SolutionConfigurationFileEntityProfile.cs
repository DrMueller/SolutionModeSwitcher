using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.ModeSwitching.Entities.Profiles
{
    public class SolutionConfigurationFileEntityProfile : Profile
    {
        public SolutionConfigurationFileEntityProfile()
        {
            CreateMap<SolutionConfigurationFile, SolutionConfigurationFileEntity>()
                .ForMember(d => d.FilePath, c => c.MapFrom(f => f.FilePath));
                //.ForMember(d => d.SolutionProjectReferences, c => c.MapFrom(f => f.SolutionProjectReferences));

            CreateMap<SolutionConfigurationFileEntity, SolutionConfigurationFile>()
                .ConvertUsing(
                    dto =>
                    {
                        var mapper = ProvisioningServiceSingleton.Instance.GetService<IMapper>();
                        //var projectReferences = mapper.Map<SolutionProjectReferences>(dto.SolutionProjectReferences);

                        var result = new SolutionConfigurationFile(
                            dto.FilePath,
                            null, null, null, null, null);

                        return result;
                    });
        }
    }
}