using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.AssemblyReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ImportEntry;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.PostSharp;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectBuild;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.SlowCheetah;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioConfigurations;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Implementation
{
    public class XmlToProjectConfigurationFileAdapter : IXmlToProjectConfigurationFileAdapter
    {
        private readonly IAssemblyReferenceAdapter _assemblyReferenceAdapter;
        private readonly IXmlToImportEntryAdapter _importEntryAdapter;
        private readonly IInclusionEntryAdapter _inclusionEntryAdapter;
        private readonly IXmlToPostSharpConfigurationAdapter _postSharpConfigAdapter;
        private readonly IProjectBuildConfigurationAdapter _projectBuildConfigurationAdapter;
        private readonly IXmlToProjectPropertiesConfigurationAdapter _projectPropertiesConfigAdpater;
        private readonly IProjectReferenceAdapter _projectReferenceAdapter;
        private readonly ISlowCheetahConfigurationAdapter _slowCheetahConfigAdapter;
        private readonly IVisualStudioConfigurationAdapter _visualStudioConfigAdapter;

        public XmlToProjectConfigurationFileAdapter(
            IXmlToImportEntryAdapter importEntryAdapter,
            IXmlToProjectPropertiesConfigurationAdapter projectPropertiesConfigAdpater,
            IXmlToPostSharpConfigurationAdapter postSharpConfigAdapter,
            IProjectBuildConfigurationAdapter projectBuildConfigurationAdapter,
            IAssemblyReferenceAdapter assemblyReferenceAdapter,
            IInclusionEntryAdapter inclusionEntryAdapter,
            IProjectReferenceAdapter projectReferenceAdapter,
            IVisualStudioConfigurationAdapter visualStudioConfigAdapter,
            ISlowCheetahConfigurationAdapter slowCheetahConfigAdapter)
        {
            _importEntryAdapter = importEntryAdapter;
            _projectPropertiesConfigAdpater = projectPropertiesConfigAdpater;
            _postSharpConfigAdapter = postSharpConfigAdapter;
            _projectBuildConfigurationAdapter = projectBuildConfigurationAdapter;
            _assemblyReferenceAdapter = assemblyReferenceAdapter;
            _inclusionEntryAdapter = inclusionEntryAdapter;
            _projectReferenceAdapter = projectReferenceAdapter;
            _visualStudioConfigAdapter = visualStudioConfigAdapter;
            _slowCheetahConfigAdapter = slowCheetahConfigAdapter;
        }

        public ProjectConfigurationFile Adapt(string filePath)
        {
            var document = XDocument.Load(filePath);
            var importEntries = _importEntryAdapter.Adapt(document);
            var propertiesConfig = _projectPropertiesConfigAdpater.Adapt(document);
            var postSharpConfig = _postSharpConfigAdapter.Adapt(document);
            var projectBuildConfig = _projectBuildConfigurationAdapter.Adapt(document);
            var assemblyReferences = _assemblyReferenceAdapter.Adapt(document);
            var inclusionEntries = _inclusionEntryAdapter.Adapt(document);
            var projectReferences = _projectReferenceAdapter.Adapt(document);
            var visualStudioConfig = _visualStudioConfigAdapter.Adapt(document);
            var slowCheetahConfig = _slowCheetahConfigAdapter.Adapt(document);

            var result = new ProjectConfigurationFile(
                filePath,
                importEntries,
                propertiesConfig,
                postSharpConfig,
                projectBuildConfig,
                assemblyReferences,
                inclusionEntries,
                projectReferences,
                visualStudioConfig,
                slowCheetahConfig,
                null,
                null,
                null);

            return result;
        }
    }
}