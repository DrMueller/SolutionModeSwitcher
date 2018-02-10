//using System.Linq;
//using System.Xml.Linq;
//using Mmu.Sms.Common.Constants;
//using Mmu.Sms.Domain.Areas.Common.Project;
//using Mmu.Sms.Domain.Areas.Common.Project.ProjectPropertiesConfiguration;
//using Mmu.Sms.Domain.Areas.Common._LegacyProject;
//using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;

//namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Factories.Implementation
//{
//    public class ProjectPropertiesConfigurationFactory : IProjectPropertiesConfigurationFactory
//    {
//        private readonly IXmlParsingService _xmlParsingService;

//        public ProjectPropertiesConfigurationFactory(IXmlParsingService xmlParsingService)
//        {
//            _xmlParsingService = xmlParsingService;
//        }

//        public ProjectPropertiesConfiguration CreateFromDocument(XDocument document)
//        {
//            var propertyGroupElement = document.Descendants().First(f => f.Name.LocalName == ProjectConfigConstants.ConfigurationTagName).Parent;
//            var configurationName = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "Configuration");
//            var platformName = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "Platform");
//            var productVersion = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "ProductVersion");
//            var schemaVersion = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "SchemaVersion");






//            //string projectTypeGuid,
//            //ProjectOutputType outputType,
//            //string appDesignerFolder,
//            //string rootNamespace,
//            //string assemblyName,
//            //string targetFrameworkVersion,
//            //IReadOnlyCollection<MvcBuildView> mvcBuildViews,
//            //IisExpressConfiguration iisExpressConfiguration,
//            //SccConfiguration sccConfiguration,
//            //SolutionDirectory solutionDirectory,
//            //bool restorePackage,
//            //string webGreaseLibPath,
//            //bool? useGlobalApplicationHostFile,
//            //bool dontImportPostSharp,
//            //string targetFrameworkProfile,
//            //int langVersion,
//            //string nuGetPackageImportStamp)
//            //var rootNamespace = _xmlParsingService.TryParsingSubElementStringValue(configurationElement, ProjectConfigConstants.RootNamespaceLocalName);
//            //var assemblyName = _xmlParsingService.TryParsingSubElementStringValue(configurationElement, ProjectConfigConstants.AssemblyNameLocalName);

//            //return result;

//            return null;
//        }
//    }
//}