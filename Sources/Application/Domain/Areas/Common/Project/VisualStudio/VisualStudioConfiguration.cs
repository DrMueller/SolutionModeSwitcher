using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.Domain.Areas.Common.Project.VisualStudio
{
    public class VisualStudioConfiguration
    {
        public VisualStudioConfiguration(
            Maybe<VisualStudioVersion> visualStudioVersion,
            Maybe<VisualStudioToolsPath> visualStudioToolsPath)
        {
            VisualStudioVersion = visualStudioVersion;
            VisualStudioToolsPath = visualStudioToolsPath;
        }

        public Maybe<VisualStudioVersion> VisualStudioToolsPath { get; }
        public Maybe<VisualStudioToolsPath> VisualStudioVersion { get; }
    }
}