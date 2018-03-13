namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectConfigurations
{
    public class ProjectConfiguration
    {
        public ProjectConfiguration(string toolsVersion, string defaultTargets, string xmlNamespace)
        {
            ToolsVersion = toolsVersion;
            DefaultTargets = defaultTargets;
            XmlNamespace = xmlNamespace;
        }

        public string DefaultTargets { get; }
        public string ToolsVersion { get; }
        public string XmlNamespace { get; }
    }
}