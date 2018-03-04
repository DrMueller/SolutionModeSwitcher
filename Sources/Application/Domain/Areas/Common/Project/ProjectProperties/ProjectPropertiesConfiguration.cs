using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Maybes;

namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class ProjectPropertiesConfiguration
    {
        public ProjectPropertiesConfiguration(
            string configurationName,
            string platformName,
            string productVersion,
            string schemaVersion,
            string projectGuid,
            string projectTypeGuids,
            ProjectOutputType outputType,
            string appDesignerFolder,
            string rootNamespace,
            string assemblyName,
            string targetFrameworkVersion,
            string fileAlignment,
            IReadOnlyCollection<MvcBuildView> mvcBuildViews,
            Maybe<IisExpressConfiguration> iisExpressConfiguration,
            SccConfiguration sccConfiguration,
            SolutionDirectory solutionDirectory,
            bool restorePackages,
            string webGreaseLibPath,
            bool? useGlobalApplicationHostFile,
            bool? dontImportPostSharp,
            string targetFrameworkProfile,
            int langVersion,
            string nuGetPackageImportStamp)
        {
            ConfigurationName = configurationName;
            PlatformName = platformName;
            OutputType = outputType;
            ProductVersion = productVersion;
            SchemaVersion = schemaVersion;
            ProjectGuid = projectGuid;
            ProjectTypeGuids = projectTypeGuids;
            AppDesignerFolder = appDesignerFolder;
            RootNamespace = rootNamespace;
            AssemblyName = assemblyName;
            TargetFrameworkVersion = targetFrameworkVersion;
            FileAlignment = fileAlignment;
            MvcBuildViews = mvcBuildViews;
            IisExpressConfiguration = iisExpressConfiguration;
            SccConfiguration = sccConfiguration;
            SolutionDirectory = solutionDirectory;
            RestorePackages = restorePackages;
            WebGreaseLibPath = webGreaseLibPath;
            UseGlobalApplicationHostFile = useGlobalApplicationHostFile;
            DontImportPostSharp = dontImportPostSharp;
            TargetFrameworkProfile = targetFrameworkProfile;
            LangVersion = langVersion;
            NuGetPackageImportStamp = nuGetPackageImportStamp;
        }

        public string AppDesignerFolder { get; }
        public string AssemblyName { get; }
        public string ConfigurationName { get; }
        public bool? DontImportPostSharp { get; }
        public string FileAlignment { get; }
        public Maybe<IisExpressConfiguration> IisExpressConfiguration { get; }
        public int LangVersion { get; }
        public IReadOnlyCollection<MvcBuildView> MvcBuildViews { get; }
        public string NuGetPackageImportStamp { get; }
        public ProjectOutputType OutputType { get; }
        public string PlatformName { get; }
        public string ProductVersion { get; }
        public string ProjectGuid { get; }
        public string ProjectTypeGuids { get; }
        public bool RestorePackages { get; }
        public string RootNamespace { get; }
        public SccConfiguration SccConfiguration { get; }
        public string SchemaVersion { get; }
        public SolutionDirectory SolutionDirectory { get; }
        public string TargetFrameworkProfile { get; }
        public string TargetFrameworkVersion { get; }
        public bool? UseGlobalApplicationHostFile { get; }
        public string WebGreaseLibPath { get; }
    }
}