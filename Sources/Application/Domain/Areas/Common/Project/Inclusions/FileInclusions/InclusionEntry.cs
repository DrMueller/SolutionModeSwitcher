﻿namespace Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions
{
    public class InclusionEntry
    {
        public InclusionEntry(
            string includePath,
            BuildAction buildAction,
            string link,
            CopyToOutputDirectoryType copyToOutputDirectoryType,
            string subType,
            bool? excludeFromStyleCop,
            bool? designTime,
            bool? autoGen,
            string dependantUpon)
        {
            IncludePath = includePath;
            BuildAction = buildAction;
            Link = link;
            CopyToOutputDirectoryType = copyToOutputDirectoryType;
            SubType = subType;
            ExcludeFromStyleCop = excludeFromStyleCop;
            DesignTime = designTime;
            AutoGen = autoGen;
            DependantUpon = dependantUpon;
        }

        public bool? AutoGen { get; }
        public BuildAction BuildAction { get; }
        public CopyToOutputDirectoryType CopyToOutputDirectoryType { get; }
        public string DependantUpon { get; }
        public bool? DesignTime { get; }
        public bool? ExcludeFromStyleCop { get; }
        public string IncludePath { get; }
        public string Link { get; }
        public string SubType { get; }
    }
}