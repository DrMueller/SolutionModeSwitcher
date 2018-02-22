using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project._FactoriesLegacy.Implementation
{
    public class XmlProjectAssemblyReferenceFactory : IXmlProjectAssemblyReferenceFactory
    {
        public XElement CreateElement(ProjectAssemblyReference assemblyReference)
        {
            return null;

            //var result = new XElement(ProjectConfigConstants.AssemblyReferenceTagLocalName);
            //result.Add(new XAttribute(ProjectConfigConstants.IncludeAttributeName, assemblyReference.IncludeDefinition.CreateOutput()));
            //if (assemblyReference.SpecificVersion.HasValue)
            //{
            //    result.Add(new XElement(ProjectConfigConstants.SpecificVersionTagName, assemblyReference.SpecificVersion));
            //}

            //result.Add(new XElement(ProjectConfigConstants.HintPathTagName, assemblyReference.HintPath));
            //return result;
        }
    }
}
