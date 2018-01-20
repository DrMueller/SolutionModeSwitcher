using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionProperties
{
    public class HideSolutionNodeBlock : BlockElement
    {
        private readonly string _data;

        //HideSolutionNode = FALSE

        public HideSolutionNodeBlock(string data)
        {
            _data = data;
        }

        public override string CreateOutput()
        {
            return _data;
        }
    }
}