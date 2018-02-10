namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectReference
    {
        public ProjectReference(string projectGuid, string relativeProjectFileIncludePath, string assemblyName)
        {
            ProjectGuid = projectGuid;
            RelativeProjectFileIncludePath = relativeProjectFileIncludePath;
            AssemblyName = assemblyName;
        }

        public string AssemblyName { get; }
        public string ProjectGuid { get; }
        public string RelativeProjectFileIncludePath { get; }
    }
}