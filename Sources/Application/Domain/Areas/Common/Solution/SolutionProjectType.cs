namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public enum SolutionProjectType
    {
        Unknown = 0,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ms", Justification = "Domainterm")]
        KnownToBeMsBuildFormat = 1,
        SolutionFolder = 2,
        WebProject = 3,
        WebDeploymentProject = 4,
        EtpSubProject = 5
    }
}