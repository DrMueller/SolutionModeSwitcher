namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    public class TargetError
    {
        public TargetError(string condition, string text)
        {
            Condition = condition;
            Text = text;
        }

        public string Condition { get; }
        public string Text { get; }
    }
}