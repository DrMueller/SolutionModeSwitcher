namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class AspNetCompilerConfiguration
    {
        public AspNetCompilerConfiguration(
            string virtualPath,
            string physicalPath)
        {
            VirtualPath = virtualPath;
            PhysicalPath = physicalPath;
        }

        public string PhysicalPath { get; }
        public string VirtualPath { get; }
    }
}