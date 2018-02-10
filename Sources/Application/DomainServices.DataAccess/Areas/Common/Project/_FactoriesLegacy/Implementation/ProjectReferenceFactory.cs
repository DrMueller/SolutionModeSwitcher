﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy.Implementation
{
    public class ProjectReferenceFactory : IProjectReferenceFactory
    {
        public List<ProjectReference> CreateFromDocument(XDocument configDocument)
        {
            var projectReferences = configDocument.Descendants().Where(f => f.Name.LocalName == ProjectConfigConstants.ProjectReferenceTagLocalName);
            var result = projectReferences.Select(CreateProjectReferenceFromElement).ToList();
            return result;
        }

        private static ProjectReference CreateProjectReferenceFromElement(XElement element)
        {
            var includePath = element.Attributes("Include").First().Value;
            var projectGuid = element.Descendants().First(f => f.Name.LocalName == "Project").Value;
            var name = element.Descendants().First(f => f.Name.LocalName == "Name").Value;

            var result = new ProjectReference(projectGuid, includePath, name);
            return result;
        }
    }
}