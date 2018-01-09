using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectReference
    {
        public SolutionProjectReference(string blockText, string assemblyName, string guid, string absoluteProjectFilePath)
        {
            Guard.StringNotNullOrEmpty(() => blockText);
            Guard.StringNotNullOrEmpty(() => assemblyName);
            Guard.StringNotNullOrEmpty(() => guid);
            Guard.StringNotNullOrEmpty(() => absoluteProjectFilePath);

            BlockText = blockText;
            AssemblyName = assemblyName;
            Guid = guid;
            AbsoluteProjectFilePath = absoluteProjectFilePath;
        }

        public string AssemblyName { get; }
        public string BlockText { get; }
        public string Guid { get; }
        public string AbsoluteProjectFilePath { get; }
    }
}