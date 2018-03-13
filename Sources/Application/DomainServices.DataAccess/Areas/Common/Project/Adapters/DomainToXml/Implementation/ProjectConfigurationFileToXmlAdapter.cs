using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.AssemblyReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ImportEntries;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Inclusions;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.PostSharp;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectBuild;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectConfigurations;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectProperties;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ProjectReferences;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.SlowCheetah;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Targets;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.UsingTasks;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.VisualStudioConfigurations;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Implementation
{
    public class ProjectConfigurationFileToXmlAdapter : IProjectConfigurationFileToXmlAdapter
    {
        private readonly IAssemblyReferenceToXmlAdapter _assemblyReferenceAdapter;
        private readonly IInclusionEntryToXmlAdapter _compileInclusionAdapter;
        private readonly IImportEntryToXmlAdapter _importEntryAdapter;
        private readonly IPostSharpConfigurationToXmlAdapter _postSharpConfigAdapter;
        private readonly IProjectBuildConfigurationToXmlAdapter _projectBuildConfigAdapter;
        private readonly IProjectConfigurationToXmlAdapter _projectConfigAdapter;
        private readonly IProjectPropertiesConfigurationToXmlAdapter _projectPropertiesConfigAdapter;
        private readonly IProjectReferenceToXmlAdapter _projectReferenceAdapter;
        private readonly ISlowCheetahConfigurationToXmlAdapter _slowCheetahConfigAdapter;
        private readonly ITargetToXmlAdapter _targetAdapter;
        private readonly IUsingTaskToXmlAdapter _usingTaskAdapter;
        private readonly IVisualStudioConfigurationToXmlAdapter _visualStudioConfigAdapter;

        public ProjectConfigurationFileToXmlAdapter(
            IProjectConfigurationToXmlAdapter projectConfigAdapter,
            IImportEntryToXmlAdapter importEntryAdapter,
            IProjectPropertiesConfigurationToXmlAdapter projectPropertiesConfigAdapter,
            IProjectBuildConfigurationToXmlAdapter projectBuildConfigAdapter,
            IPostSharpConfigurationToXmlAdapter postSharpConfigAdapter,
            IAssemblyReferenceToXmlAdapter assemblyReferenceAdapter,
            IInclusionEntryToXmlAdapter compileInclusionAdapter,
            IProjectReferenceToXmlAdapter projectReferenceAdapter,
            IVisualStudioConfigurationToXmlAdapter visualStudioConfigAdapter,
            ISlowCheetahConfigurationToXmlAdapter slowCheetahConfigAdapter,
            IUsingTaskToXmlAdapter usingTaskAdapter,
            ITargetToXmlAdapter targetAdapter)
        {
            _projectConfigAdapter = projectConfigAdapter;
            _importEntryAdapter = importEntryAdapter;
            _projectPropertiesConfigAdapter = projectPropertiesConfigAdapter;
            _projectBuildConfigAdapter = projectBuildConfigAdapter;
            _postSharpConfigAdapter = postSharpConfigAdapter;
            _assemblyReferenceAdapter = assemblyReferenceAdapter;
            _compileInclusionAdapter = compileInclusionAdapter;
            _projectReferenceAdapter = projectReferenceAdapter;
            _visualStudioConfigAdapter = visualStudioConfigAdapter;
            _slowCheetahConfigAdapter = slowCheetahConfigAdapter;
            _usingTaskAdapter = usingTaskAdapter;
            _targetAdapter = targetAdapter;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = _projectConfigAdapter.Adapt(projectConfigFile);

            var importEntries = _importEntryAdapter.Adapt(projectConfigFile);
            var projectPropertiesConfig = _projectPropertiesConfigAdapter.Adapt(projectConfigFile);
            var buildConfigs = _projectBuildConfigAdapter.Adapt(projectConfigFile);
            var postSharpConfig = _postSharpConfigAdapter.Adapt(projectConfigFile);
            var assemblyReferences = _assemblyReferenceAdapter.Adapt(projectConfigFile);
            var compileInclusions = _compileInclusionAdapter.Adapt(projectConfigFile, BuildAction.Compile);
            var contentInclusions = _compileInclusionAdapter.Adapt(projectConfigFile, BuildAction.Content);
            var projectReferences = _projectReferenceAdapter.Adapt(projectConfigFile);
            var visualStudioConfig = _visualStudioConfigAdapter.Adapt(projectConfigFile);
            var slowCheetahConfig = _slowCheetahConfigAdapter.Adapt(projectConfigFile);
            var usingTasks = _usingTaskAdapter.Adapt(projectConfigFile);
            var targets = _targetAdapter.Adapt(projectConfigFile);

            result.Add(projectPropertiesConfig);
            result.Add(buildConfigs);
            postSharpConfig.Evaluate(element => result.Add(element));
            result.Add(assemblyReferences);
            result.Add(compileInclusions);
            result.Add(contentInclusions);
            result.Add(projectReferences);
            result.Add(visualStudioConfig);
            slowCheetahConfig.Evaluate(element => result.Add(element));
            result.Add(usingTasks);
            result.Add(targets);
            result.Add(importEntries);

            //var tra = result.Descendants().First(f => f.Name.LocalName == "Import");

            //var t = tra.Attributes();
            //var xs = t.FirstOrDefault(f => f.Name.LocalName == "xmlns");

            //foreach(var descendant in result.Descendants())
            //{
            //    descendant.Attributes().FirstOrDefault(f => f.Name.LocalName == "xmlns")?.Remove();
            //}

            return result;
        }
    }
}