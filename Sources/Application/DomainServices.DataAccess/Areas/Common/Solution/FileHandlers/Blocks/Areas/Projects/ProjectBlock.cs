using System;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Projects
{
    public class ProjectBlock : BlockElement, IBlockWithGuid
    {
        //Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Fifa.Ifes.Assets", "Application\Implementation\Source\Assets\Fifa.Ifes.Assets.csproj", "{7AA549C9-17C3-4037-83B8-662AF6961619}"
        //EndProject
        private readonly string _data;

        public ProjectBlock(string data)
        {
            _data = data;
        }

        public string Guid
        {
            get
            {
                var endIndex = _data.IndexOf("}", StringComparison.OrdinalIgnoreCase);
                var startIndex = _data.IndexOf("{", endIndex + 1, StringComparison.OrdinalIgnoreCase);
                endIndex = _data.IndexOf("}", startIndex + 1, StringComparison.OrdinalIgnoreCase);

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