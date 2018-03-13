namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionHeadingElement
    {
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

        public string FormatDescription { get; }
        public string MinimalVisualStudioVersion { get; }
        public string VisualStudioDescription { get; }
        public string VisualStudioVersion { get; }
    }
}