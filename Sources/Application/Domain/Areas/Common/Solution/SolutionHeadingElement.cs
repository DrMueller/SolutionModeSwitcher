namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionHeadingElement
    {
        public string FormatDescription { get; }
        public string VisualStudioDescription { get; }
        public string VisualStudioVersion { get; }
        public string MinimalVisualStudioVersion { get; }

        //Microsoft Visual Studio Solution File, Format Version 12.00
        //# Visual Studio 14
        //VisualStudioVersion = 14.0.25420.1
        //MinimumVisualStudioVersion = 10.0.40219.1

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
