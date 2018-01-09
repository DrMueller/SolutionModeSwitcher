using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Application.Areas.Domain.Common.Project.Factories.SubFactories;
using Mmu.Sms.Common.Constants;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Common.LanguageExtensions.Proxies.Implementation;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.Areas.Common.Project.Factories.SubFactories;

namespace Mmu.Sms.Application.Areas.Domain.Common.Project.Factories.Implementation
{
    public class ProjectConfigurationDocumentFactory : IProjectConfigurationDocumentFactory
    {
        private readonly IProjectAssemblyReferenceFactory _assemblyReferenceFactory;
        private readonly IXmlProjectAssemblyReferenceFactory _xmlAssemblyReferenceFactory;

        public ProjectConfigurationDocumentFactory(IXmlProjectAssemblyReferenceFactory xmlAssemblyReferenceFactory, IProjectAssemblyReferenceFactory assemblyReferenceFactory)
        {
            _xmlAssemblyReferenceFactory = xmlAssemblyReferenceFactory;
            _assemblyReferenceFactory = assemblyReferenceFactory;
        }

        public IXDocumentProxy CreateDocument(ProjectConfigurationFile projectConfigFile)
        {
            var document = XDocument.Load(projectConfigFile.FilePath);
            RemoveProjectReferences(document, projectConfigFile);
            AddAssemblyReferences(document, projectConfigFile);
            return new XDocumentProxy(document);
        }

        private void AddAssemblyReferences(XDocument document, ProjectConfigurationFile projectConfig)
        {
            var assemblyReferencesFromFile = _assemblyReferenceFactory.CreateFromDocument(document);
            var assemblyReferencesToAdd = projectConfig.AssemblyReferences.Where(f => assemblyReferencesFromFile.All(r => r.IncludeDefinition.ShortName != f.IncludeDefinition.ShortName)).ToList();

            var assemblyReferenceParent = GetOrCreateAssemblyReferenceParentElement(document);

            foreach (var assemblyReference in assemblyReferencesToAdd)
            {
                var assemblyRefXmlEment = _xmlAssemblyReferenceFactory.CreateElement(assemblyReference);
                assemblyReferenceParent.Add(assemblyRefXmlEment);
            }
        }

        private static XElement GetOrCreateAssemblyReferenceParentElement(XContainer document)
        {
            var assemblyReference = document.Descendants().FirstOrDefault(f => f.Name.LocalName == ProjectConfigConstants.AssemblyReferenceTagLocalName);

            if (assemblyReference != null)
            {
                return assemblyReference.Parent;
            }

            var projectElement = document.Descendants().First(f => f.Name.LocalName == ProjectConfigConstants.ProjectTagName);
            var itemGroupElement = new XElement(ProjectConfigConstants.ItemGroupTagName);
            projectElement.Add(itemGroupElement);
            return itemGroupElement;
        }

        private static void RemoveProjectReferences(XContainer document, ProjectConfigurationFile projectConfig)
        {
            var xmlProjectReferences = document.Descendants().Where(f => f.Name.LocalName == ProjectConfigConstants.ProjectReferenceTagLocalName).ToList();

            var projectReferenceNames = projectConfig.ProjectReferences.Select(f => f.AssemblyName).ToList();
            var xmlProjectReferenceNames = xmlProjectReferences.Select(element => element.Descendants().First(f => f.Name.LocalName == "Name").Value).ToList();
            var projectReferenceNamesToRemove = xmlProjectReferenceNames.Except(projectReferenceNames).ToList();
            xmlProjectReferences.Where(element => projectReferenceNamesToRemove.Contains(element.Descendants().First(f => f.Name.LocalName == "Name").Value)).Remove();
        }
    }
}