namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class SolutionDirectory
    {
        public SolutionDirectory(string condition, string path)
        {
            Condition = condition;
            Path = path;
        }

        public string Condition { get; }
        public string Path { get; }
    }
}