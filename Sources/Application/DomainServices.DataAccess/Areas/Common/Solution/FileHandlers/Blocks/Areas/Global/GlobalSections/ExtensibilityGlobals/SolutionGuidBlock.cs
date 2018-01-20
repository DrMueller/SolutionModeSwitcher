using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.ExtensibilityGlobals
{
    public class SolutionGuidBlock : BlockElement
    {
        private readonly string _data;

        //SolutionGuid = {32379099-F76E-428A-966E-C874F28C80E7}

        public SolutionGuidBlock(string data)
        {
            _data = data;
        }

        public override string CreateOutput()
        {
            return _data;
        }
    }
}