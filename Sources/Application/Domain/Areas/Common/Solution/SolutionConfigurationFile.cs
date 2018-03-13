using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionConfigurationFile
    {
        public SolutionConfigurationFile(
            string filePath,
            SolutionHeadingElement headingElement,
            SolutionProperties solutionProperties,
            ICollection<SolutionProject> solutionProjects,
            ICollection<SolutionConfiguration> solutionConfigurations,
            GlobalExtensibilities globalExtensibilities)
        {
            Guard.StringNotNullOrEmpty(() => filePath);
            Guard.ObjectNotNull(() => headingElement);
            Guard.ObjectNotNull(() => solutionProperties);
            Guard.ObjectNotNull(() => solutionProjects);
            Guard.ObjectNotNull(() => solutionConfigurations);
            Guard.ObjectNotNull(() => globalExtensibilities);

            FilePath = filePath;
            HeadingElement = headingElement;
            SolutionProperties = solutionProperties;
            SolutionProjects = solutionProjects;
            SolutionConfigurations = solutionConfigurations;
            GlobalExtensibilities = globalExtensibilities;
        }

        public string FilePath { get; }
        public GlobalExtensibilities GlobalExtensibilities { get; }
        public SolutionHeadingElement HeadingElement { get; }
        public ICollection<SolutionConfiguration> SolutionConfigurations { get; }
        public ICollection<SolutionProject> SolutionProjects { get; }
        public SolutionProperties SolutionProperties { get; }
    }
}