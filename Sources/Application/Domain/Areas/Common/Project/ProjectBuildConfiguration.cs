namespace Mmu.Sms.Domain.Areas.Common.Project
{
    public class ProjectBuildConfiguration
    {
        public ProjectBuildConfiguration(
            string condition,
            bool? debugSymbols,
            string debugType,
            bool optimize,
            string outputPath,
            string defineConstants,
            string errorReport,
            int warningLevel,
            string codeAnalysisRuleSet,
            bool? runCodeAnalysis,
            int? noWarn,
            bool? usePostSharp,
            string postSharpDisabledMessages,
            string documentationFile,
            int langVersion
        )
        {
            Condition = condition;
            DebugSymbols = debugSymbols;
            DebugType = debugType;
            Optimize = optimize;
            OutputPath = outputPath;
            DefineConstants = defineConstants;
            ErrorReport = errorReport;
            WarningLevel = warningLevel;
            CodeAnalysisRuleSet = codeAnalysisRuleSet;
            RunCodeAnalysis = runCodeAnalysis;
            NoWarn = noWarn;
            UsePostSharp = usePostSharp;
            PostSharpDisabledMessages = postSharpDisabledMessages;
            DocumentationFile = documentationFile;
            LangVersion = langVersion;
        }

        public string CodeAnalysisRuleSet { get; }
        public string Condition { get; }
        public bool? DebugSymbols { get; }
        public string DebugType { get; }
        public string DefineConstants { get; }
        public string DocumentationFile { get; }
        public string ErrorReport { get; }
        public int LangVersion { get; }
        public int? NoWarn { get; }
        public bool Optimize { get; }
        public string OutputPath { get; }
        public string PostSharpDisabledMessages { get; }
        public bool? RunCodeAnalysis { get; }
        public bool? UsePostSharp { get; }
        public int WarningLevel { get; }
    }
}