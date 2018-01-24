using System.Collections.Generic;
using Microsoft.Build.Construction;
using Mmu.Sms.Domain.Areas.Common.Solution;
using Mmu.Sms.Domain.Areas.Common.Solution._legacy;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.Factories.Implementation
{
    public class SolutionProjectReferencesFactory : ISolutionProjectReferencesFactory
    {
        private readonly ISolutionFileBlockFactory _solutionFileBlockFactory;
        private readonly ISolutionProjectConfigurationFactory _solutionProjectConfigurationFactory;

        public SolutionProjectReferencesFactory(
            ISolutionFileBlockFactory solutionFileBlockFactory,
            ISolutionProjectConfigurationFactory solutionProjectConfigurationFactory)
        {
            _solutionFileBlockFactory = solutionFileBlockFactory;
            _solutionProjectConfigurationFactory = solutionProjectConfigurationFactory;
        }

        public SolutionProjectReferences Create(string solutionFilePath)
        {
            var entries = new List<SolutionProjectReference>();
            _solutionFileBlockFactory.Initialize(solutionFilePath);
            var solutionFile = SolutionFile.Parse(solutionFilePath);

            foreach (var project in solutionFile.ProjectsInOrder)
            {
                var configurations = _solutionProjectConfigurationFactory.Create(project);
                var solutionProjectBlock = _solutionFileBlockFactory.FindProjectBlock(project.ProjectName);

                var entry = new SolutionProjectReference(
                    solutionProjectBlock.Data,
                    project.ProjectName,
                    project.ProjectGuid,
                    project.ParentProjectGuid,
                    project.AbsolutePath,
                    configurations);
                entries.Add(entry);
            }

            var result = new SolutionProjectReferences(entries);
            return result;
        }
    }
}