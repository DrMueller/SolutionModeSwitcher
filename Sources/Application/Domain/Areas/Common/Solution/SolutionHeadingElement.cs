namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionHeadingElement
    {
        public string FormatDescription { get; }
        public string VisualStudioDescription { get; }
        public string VisualStudioVersion { get; }
        public string MinimalVisualStudioVersion { get; }

        public SolutionHeadingElement(
            string formatDescription,
            string visualStudioDescription,
            string visualStudioVersion,
            string minimalVisualStudioVersion
            )
        {
            FormatDescription = formatDescription;
            VisualStudioDescription = visualStudioDescription;
            VisualStudioVersion = visualStudioVersion;
            MinimalVisualStudioVersion = minimalVisualStudioVersion;
        }
    }
}
