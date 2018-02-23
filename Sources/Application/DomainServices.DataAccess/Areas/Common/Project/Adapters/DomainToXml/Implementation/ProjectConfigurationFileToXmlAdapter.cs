using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ImportEntries;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Implementation
{
    public class ProjectConfigurationFileToXmlAdapter : IProjectConfigurationFileToXmlAdapter
    {
        private readonly IImportEntryToXmlAdapter _importEntryToXmlAdapter;

        public ProjectConfigurationFileToXmlAdapter(IImportEntryToXmlAdapter importEntryToXmlAdapter)
        {
            _importEntryToXmlAdapter = importEntryToXmlAdapter;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = new XElement("Project");


            //IXmlToProjectPropertiesConfigurationAdapter projectPropertiesConfigAdpater,
            //    IXmlToPostSharpConfigurationAdapter postSharpConfigAdapter,
            //IProjectBuildConfigurationAdapter projectBuildConfigurationAdapter,
            //    IAssemblyReferenceAdapter assemblyReferenceAdapter,
            //IInclusionEntryAdapter inclusionEntryAdapter,
            //    IProjectReferenceAdapter projectReferenceAdapter,
            //IVisualStudioConfigurationAdapter visualStudioConfigAdapter,
            //    ISlowCheetahConfigurationAdapter slowCheetahConfigAdapter,
            //ITargetConfigurationAdapter targetConfigurationAdapter,
            //    IVisualStudioExtensionsConfigurationAdapter visualStudioExtensionsAdapter,
            //IUsingTaskAdapter usingTaskAdapter)


            var importEntries = _importEntryToXmlAdapter.Adapt(projectConfigFile);
            result.Add(importEntries);

            return result;
        }
    }
}