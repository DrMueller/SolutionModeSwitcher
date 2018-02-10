using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties.Implementation
{
    public class XmlToProjectPropertiesConfigurationAdapter : IXmlToProjectPropertiesConfigurationAdapter
    {
        private readonly IXmlToIisExpressConfigurationAdapter _iisExpressConfigurationAdapter;
        private readonly IXmlToMvcBuildViewAdapter _mvcBuildViewAdapter;
        private readonly IXmlToProjectOutputTypeAdapter _projectOutputTypeAdapter;
        private readonly IXmlToSscConfigurationAdapter _sccConfigurationAdapter;
        private readonly IXmlToSolutionDirectoryAdapter _solutionDirectoryAdapter;
        private readonly IXmlParsingService _xmlParsingService;

        public XmlToProjectPropertiesConfigurationAdapter(
            IXmlParsingService xmlParsingService,
            IXmlToMvcBuildViewAdapter mvcBuildViewAdapter,
            IXmlToIisExpressConfigurationAdapter iisExpressConfigurationAdapter,
            IXmlToSscConfigurationAdapter sccConfigurationAdapter,
            IXmlToSolutionDirectoryAdapter solutionDirectoryAdapter,
            IXmlToProjectOutputTypeAdapter projectOutputTypeAdapter)
        {
            _xmlParsingService = xmlParsingService;
            _mvcBuildViewAdapter = mvcBuildViewAdapter;
            _iisExpressConfigurationAdapter = iisExpressConfigurationAdapter;
            _sccConfigurationAdapter = sccConfigurationAdapter;
            _solutionDirectoryAdapter = solutionDirectoryAdapter;
            _projectOutputTypeAdapter = projectOutputTypeAdapter;
        }

        public ProjectPropertiesConfiguration Adapt(XDocument document)
        {
            var propertyGroupElement = document.Descendants().First(f => f.Name.LocalName == "Configuration").Parent;

            var configurationName = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "Configuration");
            var platformName = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "Platform");
            var productVersion = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "ProductVersion");
            var schemaVersion = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "SchemaVersion");
            var projectTypeGuids = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "ProjectTypeGuids");
            var outputType = _projectOutputTypeAdapter.Adapt(propertyGroupElement);
            var appDesignFolder = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "AppDesignerFolder");
            var rootNamespace = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "RootNamespace");
            var assemblyName = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "AssemblyName");
            var targetFrameworkVersion = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "TargetFrameworkVersion");
            var mvcBuildViews = _mvcBuildViewAdapter.Adapt(propertyGroupElement);
            var iisExpressConfiguration = _iisExpressConfigurationAdapter.Adapt(propertyGroupElement);
            var sccConfiguration = _sccConfigurationAdapter.Adapt(propertyGroupElement);
            var solutionDirectory = _solutionDirectoryAdapter.Adapt(propertyGroupElement);
            var restorePackages = _xmlParsingService.ParseSubElementValue<bool>(propertyGroupElement, "RestorePackages");
            var webGreaseLibPath = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "WebGreaseLibPath");
            var useGlobalApplicationHostFîle = _xmlParsingService.TryParsingSubElementValue<bool>(propertyGroupElement, "UseGlobalApplicationHostFile");
            var dontImportPostSharp = _xmlParsingService.TryParsingSubElementValue<bool>(propertyGroupElement, "DontImportPostSharp");
            var targetFrameworkProfile = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "TargetFrameworkProfile");
            var langVersion = _xmlParsingService.ParseSubElementValue<int>(propertyGroupElement, "LangVersion");
            var nugetPackageImportTimeStamp = _xmlParsingService.TryParsingSubElementStringValue(propertyGroupElement, "NuGetPackageImportStamp");

            var result = new ProjectPropertiesConfiguration(
                configurationName,
                platformName,
                productVersion,
                schemaVersion,
                projectTypeGuids,
                outputType,
                appDesignFolder,
                rootNamespace,
                assemblyName,
                targetFrameworkVersion,
                mvcBuildViews,
                iisExpressConfiguration,
                sccConfiguration,
                solutionDirectory,
                restorePackages,
                webGreaseLibPath,
                useGlobalApplicationHostFîle,
                dontImportPostSharp,
                targetFrameworkProfile,
                langVersion,
                nugetPackageImportTimeStamp);

            return result;
        }
    }
}