using StructureMap;

namespace Mmu.Sms.DomainServices.Shell.Infrastructure.Ioc
{
    public class InfrastructureRegistry : Registry
    {
        public InfrastructureRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly(); // Scan this assembly
                    scan.WithDefaultConventions();
                });
        }
    }
}