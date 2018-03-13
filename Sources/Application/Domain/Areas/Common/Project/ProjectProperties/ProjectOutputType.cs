namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class ProjectOutputType
    {
        public ProjectOutputType(string fileExtension, string description)
        {
            FileExtension = fileExtension;
            Description = description;
        }

        public string Description { get; }
        public string FileExtension { get; }
    }
}