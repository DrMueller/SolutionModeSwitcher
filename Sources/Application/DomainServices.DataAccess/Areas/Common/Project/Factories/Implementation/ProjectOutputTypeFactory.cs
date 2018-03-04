using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
{
    public class ProjectOutputTypeFactory : IProjectOutputTypeFactory
    {
        public ProjectOutputType CreateFromDescription(string description)
        {
            var upperDescription = description?.ToUpperInvariant();

            switch (upperDescription)
            {
                case "LIBRARY":
                {
                    return new ProjectOutputType(".dll", "Library");
                }
                case "WINEXE":
                {
                    return new ProjectOutputType(".exe", "WinExe");
                }
                case "EXE":
                {
                    return new ProjectOutputType(".exe", "Exe");
                }
                default:
                {
                    return new ProjectOutputType(string.Empty, string.Empty);
                }
            }
        }
    }
}