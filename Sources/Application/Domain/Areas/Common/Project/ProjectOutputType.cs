namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectOutputType
    {
        public ProjectOutputType(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public static ProjectOutputType ConsoleApplication { get; } = new ProjectOutputType(".exe");
        public string FileExtension { get; }
        public static ProjectOutputType Library { get; } = new ProjectOutputType(".dll");
        public static ProjectOutputType None { get; } = new ProjectOutputType(string.Empty);
        public static ProjectOutputType WindowsApplication { get; } = new ProjectOutputType(".exe");

        public static ProjectOutputType Parse(string outputNme)
        {
            var outputStrLower = outputNme?.ToUpperInvariant();

            switch (outputStrLower)
            {
                case "LIBRARY":
                {
                    return Library;
                }
                case "WINEXE":
                {
                    return WindowsApplication;
                }
                case "EXE":
                {
                    return ConsoleApplication;
                }
                default:
                {
                    return None;
                }
            }
        }
    }
}