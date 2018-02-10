namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectOutputType
    {
        public ProjectOutputType(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public string FileExtension { get; }
    }
}