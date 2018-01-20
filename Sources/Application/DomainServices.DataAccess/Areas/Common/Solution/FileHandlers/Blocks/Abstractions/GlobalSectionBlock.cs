using System.Collections.Generic;
using System.Text;
using Mmu.Sms.Common.LanguageExtensions.Invariance;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions
{
    public class GlobalSectionBlock : BlockElement
    {
        private readonly string _endData;
        private readonly IReadOnlyCollection<BlockElement> _elements;
        private readonly string _startData;

        public GlobalSectionBlock(string startData, string endData, IReadOnlyCollection<BlockElement> elements)
        {
            Guard.StringNotNullOrEmpty(() => startData);
            Guard.StringNotNullOrEmpty(() => endData);
            Guard.ObjectNotNull(() => elements);

            _startData = startData;
            _endData = endData;
            _elements = elements;
            _elements = elements;
        }

        public override string CreateOutput()
        {
            var sb = new StringBuilder();

            sb.Append(_startData);

            foreach (var element in _elements)
            {
                sb.Append(element.CreateOutput());
            }

            sb.Append(_endData);

            var result = sb.ToString();
            return result;
        }
    }
}