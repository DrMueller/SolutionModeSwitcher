namespace Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah
{
    public class SlowCheetahNugetImport
    {
        public SlowCheetahNugetImport(string condition, string importPath)
        {
            Condition = condition;
            ImportPath = importPath;
        }

        public string Condition { get; }
        public string ImportPath { get; }
    }
}