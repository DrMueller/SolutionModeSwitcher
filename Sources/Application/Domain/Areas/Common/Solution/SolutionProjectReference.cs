using System.Collections.Generic;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.Domain.Areas.Common.Solution
{
    public class SolutionProjectReference
    {
        public SolutionProjectReference(
            string blockText,
            string assemblyName,
            string guid,
            string parentGuid,
            string absoluteProjectFilePath,
            IReadOnlyCollection<SolutionProjectConfiguration> configurations)
        {
            Guard.StringNotNullOrEmpty(() => blockText);
            Guard.StringNotNullOrEmpty(() => assemblyName);
            Guard.StringNotNullOrEmpty(() => guid);
            Guard.StringNotNullOrEmpty(() => absoluteProjectFilePath);
            Guard.ObjectNotNull(() => configurations);

            BlockText = blockText;
            AssemblyName = assemblyName;
            Guid = guid;
            ParentGuid = parentGuid;
            AbsoluteProjectFilePath = absoluteProjectFilePath;
            Configurations = configurations;
        }

        public string AbsoluteProjectFilePath { get; }
        public string AssemblyName { get; }
        public string BlockText { get; }
        public IReadOnlyCollection<SolutionProjectConfiguration> Configurations { get; }
        public string Guid { get; }
        public string ParentGuid { get; }
    }
}