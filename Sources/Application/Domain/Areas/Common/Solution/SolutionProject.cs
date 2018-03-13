using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProject
    {
        public SolutionProject(
            string projectName,
            string relativePath,
            string absolutePath,
            string projectGuid,
            string parentProjectGuid,
            SolutionProjectType solutionProjectType,
            Maybe<WebsiteProperties> websiteProperties,
            IReadOnlyCollection<string> dependencyProjectGuids,
            IReadOnlyCollection<SolutionProjectConfiguration> configurations,
            IReadOnlyCollection<SolutionProjectItem> items)
        {
            ProjectName = projectName;
            RelativePath = relativePath;
            AbsolutePath = absolutePath;
            ProjectGuid = projectGuid;
            ParentProjectGuid = parentProjectGuid;
            DependencyProjectGuids = dependencyProjectGuids;
            SolutionProjectType = solutionProjectType;
            WebsiteProperties = websiteProperties;
            Configurations = configurations;
            Items = items;
        }

        public string AbsolutePath { get; }
        public IReadOnlyCollection<SolutionProjectConfiguration> Configurations { get; }
        public IReadOnlyCollection<string> DependencyProjectGuids { get; }
        public IReadOnlyCollection<SolutionProjectItem> Items { get; }
        public string ParentProjectGuid { get; }
        public string ProjectGuid { get; }
        public string ProjectName { get; }
        public string RelativePath { get; }
        public SolutionProjectType SolutionProjectType { get; }
        public Maybe<WebsiteProperties> WebsiteProperties { get; }
    }
}