using System;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.NestedProjects
{
    public class HierarchyEntryBlock : BlockElement, IBlockWithGuid
    {
        private readonly string _data;

        // {8560F780-A8E0-43A0-B49A-EBD0D10C0E88} = {97D93079-E9CB-45BC-B8E4-FD6C86031261}

        public HierarchyEntryBlock(string data)
        {
            _data = data;
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