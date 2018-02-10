namespace Mmu.Sms.Domain.Areas.Common.Project.Tasks
{
    public class UsingTask
    {
        public UsingTask(string taskName, string assemblyFile)
        {
            TaskName = taskName;
            AssemblyFile = assemblyFile;
        }

        public string AssemblyFile { get; }
        public string TaskName { get; }
    }
}