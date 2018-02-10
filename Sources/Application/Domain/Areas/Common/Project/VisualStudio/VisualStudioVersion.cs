namespace Mmu.Sms.Domain.Areas.Common.Project.VisualStudio
{
    public class VisualStudioVersion
    {
        public VisualStudioVersion(string condition, string version)
        {
            Condition = condition;
            Version = version;
        }

        public string Condition { get; }
        public string Version { get; }
    }
}