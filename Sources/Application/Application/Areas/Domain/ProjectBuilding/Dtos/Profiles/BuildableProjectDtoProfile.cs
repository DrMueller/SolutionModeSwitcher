using AutoMapper;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.ProjectBuilding;

namespace Mmu.Sms.Application.Areas.Domain.ProjectBuilding.Dtos.Profiles
{
    public class BuildableProjectDtoProfile : Profile
    {
        public BuildableProjectDtoProfile()
        {
            CreateMap<BuildableProject, BuildableProjectDto>()
                .ForMember(d => d.FilePath, c => c.MapFrom(f => f.FilePath))
                .ForMember(d => d.FileName, MapFileName);
        }

        private void MapFileName(IMemberConfigurationExpression<BuildableProject, BuildableProjectDto, string> memberConfigurationExpression)
        {
            var pathProxy = ProvisioningServiceSingleton.Instance.GetService<IPathProxy>();
            memberConfigurationExpression.MapFrom(f => pathProxy.GetFileName(f.FilePath));
        }
    }
}