using System.Xml.Linq;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.Application.Areas.Domain.Common.Project.Factories.SubFactories.Implementation
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