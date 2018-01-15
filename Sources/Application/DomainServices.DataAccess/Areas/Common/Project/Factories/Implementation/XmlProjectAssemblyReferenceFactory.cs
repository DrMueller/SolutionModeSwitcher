using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
{
    public class XmlProjectAssemblyReferenceFactory : IXmlProjectAssemblyReferenceFactory
    {
        public XElement CreateElement(ProjectAssemblyReference assemblyReference)
        {
            var result = new XElement(ProjectConfigConstants.AssemblyReferenceTagLocalName);
            result.Add(new XAttribute(ProjectConfigConstants.IncludeAttributeName, assemblyReference.IncludeDefinition.CreateOutput()));
            if (assemblyReference.SpecificVersion.HasValue)
            {
                result.Add(new XElement(ProjectConfigConstants.SpecificVersionTagName, assemblyReference.SpecificVersion));
            }

            result.Add(new XElement(ProjectConfigConstants.HintPathTagName, assemblyReference.HintPath));
            return result;
        }
    }
}
