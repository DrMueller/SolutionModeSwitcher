using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Project.ProjectProperties
{
    public class MvcBuildView
    {
        public MvcBuildView(string condition, bool buildViews)
        {
            Guard.StringNotNullOrEmpty(() => condition);

            Condition = condition;
            BuildViews = buildViews;
        }

        public bool BuildViews { get; }
        public string Condition { get; }
    }
}