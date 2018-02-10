using System.Collections.Generic;

namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class ProjectPropertiesConfiguration
    {
        public ProjectPropertiesConfiguration(
            string configurationName,
            string platformName,
            string productVersion,
            string schemaVersion,
            string projectTypeGuids,
            ProjectOutputType outputType,
            string appDesignerFolder,
            string rootNamespace,
            string assemblyName,
            string targetFrameworkVersion,
            IReadOnlyCollection<MvcBuildView> mvcBuildViews,
            IisExpressConfiguration iisExpressConfiguration,
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
            ProjectTypeGuids = projectTypeGuids;
            AppDesignerFolder = appDesignerFolder;
            RootNamespace = rootNamespace;
            AssemblyName = assemblyName;
            TargetFrameworkVersion = targetFrameworkVersion;
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
        public IisExpressConfiguration IisExpressConfiguration { get; }
        public int LangVersion { get; }
        public IReadOnlyCollection<MvcBuildView> MvcBuildViews { get; }
        public string NuGetPackageImportStamp { get; }
        public ProjectOutputType OutputType { get; }
        public string PlatformName { get; }
        public string ProductVersion { get; }
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