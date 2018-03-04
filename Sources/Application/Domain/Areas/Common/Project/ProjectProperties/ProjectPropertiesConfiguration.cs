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
            bool? doNotImportPostSharp,
            string targetFrameworkProfile,
            int langVersion,
            string nugetPackageImportstamp)
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
            DoNotImportPostSharp = doNotImportPostSharp;
            TargetFrameworkProfile = targetFrameworkProfile;
            LangVersion = langVersion;
            NugetPackageImportstamp = nugetPackageImportstamp;
        }

        public string AppDesignerFolder { get; }
        public string AssemblyName { get; }
        public string ConfigurationName { get; }
        public bool? DoNotImportPostSharp { get; }
        public string FileAlignment { get; }
        public Maybe<IisExpressConfiguration> IisExpressConfiguration { get; }
        public int LangVersion { get; }
        public IReadOnlyCollection<MvcBuildView> MvcBuildViews { get; }
        public string NugetPackageImportstamp { get; }
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