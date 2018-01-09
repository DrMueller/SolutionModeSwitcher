using AutoMapper;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Infrastructure.Ioc.Handlers;
using Mmu.Sms.Common.Ioc;
using StructureMap;

namespace Mmu.Sms.Application.Infrastructure.Ioc
{
    public static class IocInitialization
    {
        public static void InitializeProvisioningService()
        {
            var container = new Container();

            container.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            scan.AssembliesAndExecutablesFromApplicationBaseDirectory();
                            scan.LookForRegistries();
                            scan.WithDefaultConventions();
                        });

                    config.For<IInformationConfigurationService>().Singleton();
                    config.For<IInformationPublishingService>().Singleton();
                });

            var provisioningService = container.GetInstance<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);

            container.Configure(AddAutoMapper);
        }

        private static void AddAutoMapper(IProfileRegistry profileRegistry)
        {
            var profiles = AssemblyHandler.GetProfileTypes();

            var mapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }
                });

            var mapper = mapperConfiguration.CreateMapper();
            profileRegistry.For<IMapper>().Use(mapper);
        }
    }
}