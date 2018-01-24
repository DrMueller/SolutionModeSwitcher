namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public enum SolutionProjectType
    {
        //
        // Summary:
        //     Everything else besides the below well-known project types.
        Unknown = 0,

        //
        // Summary:
        //     C#, VB, and VJ# projects
        KnownToBeMsBuildFormat = 1,

        //
        // Summary:
        //     Solution folders appear in the .sln file, but aren't buildable projects.
        SolutionFolder = 2,

        //
        // Summary:
        //     ASP.NET projects
        WebProject = 3,

        //
        // Summary:
        //     Web Deployment (.wdproj) projects
        WebDeploymentProject = 4,

        //
        // Summary:
        //     Project inside an Enterprise Template project
        EtpSubProject = 5
    }
}