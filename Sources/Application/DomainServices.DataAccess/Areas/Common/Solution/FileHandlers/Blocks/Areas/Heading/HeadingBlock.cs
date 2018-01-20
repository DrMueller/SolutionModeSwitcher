using Mmu.Sms.Common.LanguageExtensions.Invariance;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Heading
{
    public class HeadingBlock : BlockElement
    {
        private readonly string _data;

//        Microsoft Visual Studio Solution File, Format Version 12.00
//        # Visual Studio 14
//        VisualStudioVersion = 14.0.25420.1
//        MinimumVisualStudioVersion = 10.0.40219.1

        public HeadingBlock(string data)
        {
            Guard.StringNotNullOrEmpty(() => data);
            _data = data;
        }

        public override string CreateOutput()
        {
            return _data;
        }
    }
}