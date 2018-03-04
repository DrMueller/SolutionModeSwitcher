namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectOutputType
    {
        public ProjectOutputType(string fileExtension, string description)
        {
            FileExtension = fileExtension;
            Description = description;
        }

        public string FileExtension { get; }
        public string Description { get; }
    }
}