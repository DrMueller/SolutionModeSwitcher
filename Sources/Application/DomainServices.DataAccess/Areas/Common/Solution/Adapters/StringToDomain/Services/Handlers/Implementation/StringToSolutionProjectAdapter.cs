using System.Collections.Generic;
using Microsoft.Build.Construction;
using Mmu.Sms.Domain.Areas.Common.Solution;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.StringToDomain.Services.Handlers.Implementation
{
    public class StringToSolutionProjectAdapter : IStringToSolutionProjectAdapter
    {
        private readonly IStringToSolutionProjectConfigurationAdapter _solutionProjectConfigurationAdapter;
        private readonly IStringToSolutionProjectItemAdapter _solutionProjectItemAdapter;
        private readonly IStringToWebsitePropertiesAdapter _websitePropertiesAdapter;

        public StringToSolutionProjectAdapter(
            IStringToSolutionProjectItemAdapter solutionProjectItemAdapter,
            IStringToWebsitePropertiesAdapter websitePropertiesAdapter,
            IStringToSolutionProjectConfigurationAdapter solutionProjectConfigurationAdapter)
        {
            _solutionProjectItemAdapter = solutionProjectItemAdapter;
            _websitePropertiesAdapter = websitePropertiesAdapter;
            _solutionProjectConfigurationAdapter = solutionProjectConfigurationAdapter;
        }

        public ICollection<SolutionProject> Adapt(string filePath, List<string> solutionDataLines)
        {
            var solutionFile = SolutionFile.Parse(filePath);
            var result = new List<SolutionProject>();

            foreach (var nativeProject in solutionFile.ProjectsInOrder)
            {
                var items = _solutionProjectItemAdapter.Adapt(nativeProject.ProjectGuid, solutionDataLines);
                var websiteProperties = _websitePropertiesAdapter.Adapt(nativeProject.ProjectGuid, solutionDataLines);

                var configurations = _solutionProjectConfigurationAdapter.Adapt(nativeProject.ProjectGuid, solutionDataLines);

                var solutionProject = new SolutionProject(
                    nativeProject.ProjectName,
                    nativeProject.RelativePath,
                    nativeProject.ProjectGuid,
                    nativeProject.ParentProjectGuid,
                    MapSolutionProjectType(nativeProject.ProjectType),
                    websiteProperties,
                    nativeProject.Dependencies,
                    configurations,
                    items);

                result.Add(solutionProject);
            }

            return result;
        }

        private static Domain.Areas.Common.Solution.SolutionProjectType MapSolutionProjectType(Microsoft.Build.Construction.SolutionProjectType nativeSolutionProjectType)
        {
            switch (nativeSolutionProjectType)
            {
                case Microsoft.Build.Construction.SolutionProjectType.EtpSubProject:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.EtpSubProject;
                }

                case Microsoft.Build.Construction.SolutionProjectType.KnownToBeMSBuildFormat:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.KnownToBeMsBuildFormat;
                }

                case Microsoft.Build.Construction.SolutionProjectType.SolutionFolder:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.SolutionFolder;
                }

                case Microsoft.Build.Construction.SolutionProjectType.Unknown:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.Unknown;
                }

                case Microsoft.Build.Construction.SolutionProjectType.WebDeploymentProject:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.WebDeploymentProject;
                }
                case Microsoft.Build.Construction.SolutionProjectType.WebProject:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.WebProject;
                }
                default:
                {
                    return Domain.Areas.Common.Solution.SolutionProjectType.Unknown;
                }
            }
        }
    }
}