namespace Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah
{
    public class SlowCheetahTargets
    {
        public SlowCheetahTargets(string condition, string targets)
        {
            Condition = condition;
            Targets = targets;
        }

        public string Condition { get; }
        public string Targets { get; }
    }
}