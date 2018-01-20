using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Abstractions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Solution.FileHandlers.Blocks.Areas.Global.GlobalSections.SolutionConfigurationPlatforms
{
    public class ConfigurationEntryBlock : BlockElement
    {
        private readonly string _data;

        // Debug|Any CPU = Debug|Any CPU

        public ConfigurationEntryBlock(string data)
        {
            _data = data;
        }

        public override string CreateOutput()
        {
            return _data;
        }
    }
}