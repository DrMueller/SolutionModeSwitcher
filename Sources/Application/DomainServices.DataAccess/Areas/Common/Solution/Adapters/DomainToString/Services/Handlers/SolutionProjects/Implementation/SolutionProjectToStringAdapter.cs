using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Adapters.DomainToString.Services.Handlers.SolutionProjects.Implementation
{
    public class SolutionProjectToStringAdapter : ISolutionProjectToStringAdapter
    {
        private readonly ISolutionProjectItemToStringAdapter _solutionProjectItemAdapter;
        private readonly ISolutionProjectTypeToStringAdapter _solutionProjectTypeAdapter;
        private readonly IWebsitePropertiesToStringAdapter _websitePropertiesAdapter;

        public SolutionProjectToStringAdapter(
            ISolutionProjectTypeToStringAdapter solutionProjectTypeAdapter,
            ISolutionProjectItemToStringAdapter solutionProjectItemAdapter,
            IWebsitePropertiesToStringAdapter websitePropertiesAdapter)
        {
            _solutionProjectTypeAdapter = solutionProjectTypeAdapter;
            _solutionProjectItemAdapter = solutionProjectItemAdapter;
            _websitePropertiesAdapter = websitePropertiesAdapter;
        }

        public void Adapt(IEnumerable<SolutionProject> solutionProjects, IExtendedStringBuilder sb)
        {
            foreach (var solutionProject in solutionProjects)
            {
                AdaptSolutionProject(solutionProject, sb);
            }
        }

        private void AdaptSolutionProject(SolutionProject solutionProject, IExtendedStringBuilder sb)
        {
            var projectTypeGuid = _solutionProjectTypeAdapter.AdaptToGuid(solutionProject.SolutionProjectType);
            var entryLine = $"Project(\"{projectTypeGuid}\") = \"{solutionProject.ProjectName}\", \"{solutionProject.RelativePath}\", \"{solutionProject.ProjectGuid}\"";

            sb.AppendLine(entryLine);
            _solutionProjectItemAdapter.Adapt(solutionProject.Items, sb);
            _websitePropertiesAdapter.Adapt(solutionProject.WebsiteProperties, sb);
            sb.AppendLine("EndProject");
        }
    }
}