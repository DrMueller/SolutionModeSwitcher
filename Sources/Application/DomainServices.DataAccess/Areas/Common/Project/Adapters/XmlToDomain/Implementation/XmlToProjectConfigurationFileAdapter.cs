using System.Diagnostics;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.AssemblyReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ImportEntries;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.PostSharp;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectBuild;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectConfigurations;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ProjectReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.SlowCheetah;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Targets;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.UsingTasks;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioConfigurations;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.VisualStudioExtensions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Implementation
{
    public class XmlToProjectConfigurationFileAdapter : IXmlToProjectConfigurationFileAdapter
    {
        private readonly IAssemblyReferenceAdapter _assemblyReferenceAdapter;
        private readonly IXmlToImportEntryAdapter _importEntryAdapter;
        private readonly IInclusionEntryAdapter _inclusionEntryAdapter;
        private readonly IXmlToPostSharpConfigurationAdapter _postSharpConfigAdapter;
        private readonly IProjectBuildConfigurationAdapter _projectBuildConfigurationAdapter;
        private readonly IXmlToProjectConfigurationAdapter _projectConfigAdapter;
        private readonly IXmlToProjectPropertiesConfigurationAdapter _projectPropertiesConfigAdpater;
        private readonly IProjectReferenceAdapter _projectReferenceAdapter;
        private readonly ISlowCheetahConfigurationAdapter _slowCheetahConfigAdapter;
        private readonly ITargetAdapter _targetAdapter;
        private readonly IUsingTaskAdapter _usingTaskAdapter;
        private readonly IVisualStudioConfigurationAdapter _visualStudioConfigAdapter;
        private readonly IVisualStudioExtensionsConfigurationAdapter _visualStudioExtensionsAdapter;

        public XmlToProjectConfigurationFileAdapter(
            IXmlToProjectConfigurationAdapter projectConfigAdapter,
            IXmlToImportEntryAdapter importEntryAdapter,
            IXmlToProjectPropertiesConfigurationAdapter projectPropertiesConfigAdpater,
            IXmlToPostSharpConfigurationAdapter postSharpConfigAdapter,
            IProjectBuildConfigurationAdapter projectBuildConfigurationAdapter,
            IAssemblyReferenceAdapter assemblyReferenceAdapter,
            IInclusionEntryAdapter inclusionEntryAdapter,
            IProjectReferenceAdapter projectReferenceAdapter,
            IVisualStudioConfigurationAdapter visualStudioConfigAdapter,
            ISlowCheetahConfigurationAdapter slowCheetahConfigAdapter,
            ITargetAdapter targetAdapter,
            IVisualStudioExtensionsConfigurationAdapter visualStudioExtensionsAdapter,
            IUsingTaskAdapter usingTaskAdapter)
        {
            _projectConfigAdapter = projectConfigAdapter;
            _importEntryAdapter = importEntryAdapter;
            _projectPropertiesConfigAdpater = projectPropertiesConfigAdpater;
            _postSharpConfigAdapter = postSharpConfigAdapter;
            _projectBuildConfigurationAdapter = projectBuildConfigurationAdapter;
            _assemblyReferenceAdapter = assemblyReferenceAdapter;
            _inclusionEntryAdapter = inclusionEntryAdapter;
            _projectReferenceAdapter = projectReferenceAdapter;
            _visualStudioConfigAdapter = visualStudioConfigAdapter;
            _slowCheetahConfigAdapter = slowCheetahConfigAdapter;
            _targetAdapter = targetAdapter;
            _visualStudioExtensionsAdapter = visualStudioExtensionsAdapter;
            _usingTaskAdapter = usingTaskAdapter;
        }

        public ProjectConfigurationFile Adapt(string filePath)
        {
            Debug.WriteLine(filePath);

            var document = XDocument.Load(filePath);

            var projectConfig = _projectConfigAdapter.Adapt(document);
            var importEntries = _importEntryAdapter.Adapt(document);
            var propertiesConfig = _projectPropertiesConfigAdpater.Adapt(document);
            var postSharpConfig = _postSharpConfigAdapter.Adapt(document);
            var projectBuildConfig = _projectBuildConfigurationAdapter.Adapt(document);
            var assemblyReferences = _assemblyReferenceAdapter.Adapt(document);
            var inclusionEntries = _inclusionEntryAdapter.Adapt(document);
            var projectReferences = _projectReferenceAdapter.Adapt(document);
            var visualStudioConfig = _visualStudioConfigAdapter.Adapt(document);
            var slowCheetahConfig = _slowCheetahConfigAdapter.Adapt(document);
            var targets = _targetAdapter.Adapt(document);
            var visualStudioExtensionsConfig = _visualStudioExtensionsAdapter.Adapt(document);
            var usingTasks = _usingTaskAdapter.Adapt(document);

            var result = new ProjectConfigurationFile(
                filePath,
                projectConfig,
                importEntries,
                propertiesConfig,
                postSharpConfig,
                projectBuildConfig,
                assemblyReferences,
                inclusionEntries,
                projectReferences,
                visualStudioConfig,
                slowCheetahConfig,
                targets,
                visualStudioExtensionsConfig,
                usingTasks);

            return result;
        }
    }
}