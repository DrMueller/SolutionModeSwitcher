namespace Mmu.Sms.Domain.Areas.Common.Project.VisualStudio
{
    public class VisualStudioToolsPath
    {
        public VisualStudioToolsPath(string condition, string toolsPath)
        {
            Condition = condition;
            ToolsPath = toolsPath;
        }

        public string Condition { get; }
        public string ToolsPath { get; }
    }
}