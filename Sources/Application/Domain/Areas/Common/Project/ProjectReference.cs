namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectReference
    {
        public ProjectReference(string guid, string relativeProjectFileIncludePath, string assemblyName)
        {
            Guid = guid;
            RelativeProjectFileIncludePath = relativeProjectFileIncludePath;
            AssemblyName = assemblyName;
        }

        public string AssemblyName { get; }
        public string Guid { get; }
        public string RelativeProjectFileIncludePath { get; }
    }
}