namespace Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions
{
    public enum BuildAction
    {
        None,
        Compile,
        Content,
        EmbeddedResource,
        CodeAnalysisDictionary,
        Folder,
        Reference,
        Analyzer,
        ProjectReference,
        Service,
        AppConfigWithTargetPath,
        WcfMetadata,
        WcfMetadataStorage,
        EntityDeploy,
        BootstrapperPackage,
        ApplicationDefinition,
        Page,
        AppDesigner,
        TypeScriptCompile,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ng", Justification = "Domain term")]
        NgDist
    }
}