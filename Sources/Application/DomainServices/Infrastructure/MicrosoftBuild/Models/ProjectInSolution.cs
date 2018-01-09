namespace Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Models
{
    public class ProjectInSolution
    {
        public ProjectInSolution(string absolutePath, string projectGuid, string projectName)
        {
            AbsolutePath = absolutePath;
            ProjectGuid = projectGuid;
            ProjectName = projectName;
        }

        public string AbsolutePath { get; }
        public string ProjectGuid { get; }
        public string ProjectName { get; }
    }
}