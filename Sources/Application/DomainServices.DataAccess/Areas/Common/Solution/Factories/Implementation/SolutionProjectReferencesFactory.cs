using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionProjectReferencesFactory : ISolutionProjectReferencesFactory
    {
        private readonly ISolutionFileService _solutionFileService;
        private readonly ISolutionProjectBlockFactory _solutionProjectBlockFactory;

        public SolutionProjectReferencesFactory(ISolutionProjectBlockFactory solutionProjectBlockFactory, ISolutionFileService solutionFileService)
        {
            _solutionProjectBlockFactory = solutionProjectBlockFactory;
            _solutionFileService = solutionFileService;
        }

        public SolutionProjectReferences Create(string solutionFilePath)
        {
            var entries = new List<SolutionProjectReference>();
            _solutionProjectBlockFactory.Initialize(solutionFilePath);
            var projectReferences = _solutionFileService.ParseMicrosoftBuildProjects(solutionFilePath);

            foreach (var project in projectReferences)
            {
                var solutionProjectBlock = _solutionProjectBlockFactory.FindBlock(project.ProjectName);
                var entry = new SolutionProjectReference(
                    solutionProjectBlock.Data,
                    project.ProjectName,
                    project.ProjectGuid,
                    project.AbsolutePath);
                entries.Add(entry);
            }

            var result = new SolutionProjectReferences(entries);
            return result;
        }
    }
}