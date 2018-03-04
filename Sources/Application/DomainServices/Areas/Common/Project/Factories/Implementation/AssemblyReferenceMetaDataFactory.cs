﻿using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.Implementation
{
    public class AssemblyReferenceMetaDataFactory : IAssemblyReferenceMetaDataFactory
    {
        private readonly IPathProxy _pathProxy;

        public AssemblyReferenceMetaDataFactory(IPathProxy pathProxy)
        {
            _pathProxy = pathProxy;
        }

        public string CreateHintPath(string relativeProjectFileIncludePath, ProjectConfigurationFile projectConfig)
        {
            return "";
            ////var relativeDirectory = _pathProxy.GetDirectoryName(relativeProjectFileIncludePath);
            ////var debugBuild = projectConfig.BuildConfigurations.First(f => f.ConfigurationName == ProjectBuildConfiguration.ConfigurationNameDebug);
            ////var result = Path.Combine(relativeDirectory, debugBuild.OutputPath, projectConfig.PropertiesConfiguration.AssemblyFileName);
            ////return result;
        }

        public IncludeDefinition CreateIncludeDefinition(string assemblyFileName)
        {
            var result = new IncludeDefinition(assemblyFileName, "1.0.0.0", "neutral", string.Empty, "MSIL");
            return result;
        }
    }
}