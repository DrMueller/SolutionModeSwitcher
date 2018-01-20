using System;
using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ProjectConfigurationPlatforms
{
    public class ProjectConfigurationBlock : BlockElement, IBlockWithGuid
    {
        private readonly string _data;

        // {7AA549C9-17C3-4037-83B8-662AF6961619}.Debug|Any CPU.ActiveCfg = Debug|Any CPU

        public ProjectConfigurationBlock(string data)
        {
            _data = data;
            Guard.StringNotNullOrEmpty(() => data);
        }

        public string Guid
        {
            get
            {
                var startIndex = _data.IndexOf("{", StringComparison.OrdinalIgnoreCase);
                var endIndex = _data.IndexOf("}", StringComparison.OrdinalIgnoreCase);

                if (startIndex == -1 || endIndex == -1)
                {
                    return string.Empty;
                }

                var guid = _data.Substring(startIndex, endIndex - (startIndex - 1));
                return guid;
            }
        }

        public override string CreateOutput()
        {
            return _data;
        }
    }
}