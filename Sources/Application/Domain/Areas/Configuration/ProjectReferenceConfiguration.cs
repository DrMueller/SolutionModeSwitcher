namespace Mmu.Sms.Domain.Areas.Configuration
{
    public class ProjectReferenceConfiguration
    {
        public ProjectReferenceConfiguration(string assemblyName, string absoluteProjectFilePath)
        {
            AssemblyName = assemblyName;
            AbsoluteProjectFilePath = absoluteProjectFilePath;
        }

        public string AbsoluteProjectFilePath { get; }
        public string AssemblyName { get; }
    }
}