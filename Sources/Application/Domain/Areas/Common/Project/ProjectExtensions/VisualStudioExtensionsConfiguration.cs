namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectExtensions
{
    public class VisualStudioExtensionsConfiguration
    {
        public VisualStudioExtensionsConfiguration(
            string flavorPropertiesGuid,
            bool saveServerSettingsInUserFile)
        {
            FlavorPropertiesGuid = flavorPropertiesGuid;
            SaveServerSettingsInUserFile = saveServerSettingsInUserFile;
        }

        public string FlavorPropertiesGuid { get; }
        public bool SaveServerSettingsInUserFile { get; }
    }
}