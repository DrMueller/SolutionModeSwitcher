namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class MvcBuildView
    {
        public MvcBuildView(string condition, bool buildViews)
        {
            Condition = condition;
            BuildViews = buildViews;
        }

        public bool BuildViews { get; }
        public string Condition { get; }
    }
}