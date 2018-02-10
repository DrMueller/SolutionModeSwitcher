namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class SccConfiguration
    {
        public SccConfiguration(
            string sccProjectName,
            string sccLocalPath,
            string sccAuxPath,
            string sccProvider)
        {
            SccProjectName = sccProjectName;
            SccLocalPath = sccLocalPath;
            SccAuxPath = sccAuxPath;
            SccProvider = sccProvider;
        }

        public string SccAuxPath { get; }
        public string SccLocalPath { get; }
        public string SccProjectName { get; }
        public string SccProvider { get; }
    }
}