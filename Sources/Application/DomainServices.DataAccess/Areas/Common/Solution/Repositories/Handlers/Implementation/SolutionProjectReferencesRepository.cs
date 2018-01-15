using System.Collections.Generic;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.DomainServices.Areas.Common.Solution.Factories.Handlers;
using Mmu.Sms.DomainServices.Infrastructure.MicrosoftBuild.Services;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Repositories.Handlers.Implementation
{
    public class SolutionProjectReferencesRepository : ISolutionProjectReferencesRepository
    {
        private readonly ISolutionFileService _solutionFileService;
        private readonly ISolutionProjectBlockHandler _solutionProjectBlockHandler;

        public SolutionProjectReferencesRepository(ISolutionProjectBlockHandler solutionProjectBlockHandler, ISolutionFileService solutionFileService)
        {
            _solutionProjectBlockHandler = solutionProjectBlockHandler;
            _solutionFileService = solutionFileService;
        }

        public SolutionProjectReferences Load(string solutionFilePath)
        {
            var entries = new List<SolutionProjectReference>();
            _solutionProjectBlockHandler.Initialize(solutionFilePath);
            var projectReferences = _solutionFileService.ParseMicrosoftBuildProjects(solutionFilePath);

            foreach (var project in projectReferences)
            {
                var solutionProjectBlock = _solutionProjectBlockHandler.FindBlock(project.ProjectName);
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