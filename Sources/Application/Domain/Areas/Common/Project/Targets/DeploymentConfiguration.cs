using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
    //<Target Name = "AfterPublish" >
    //< PropertyGroup >
    //< DeployedConfig >$(_DeploymentApplicationDir)$(TargetName)$(TargetExt).config$(_DeploymentFileMappingExtension)</DeployedConfig>
    //</PropertyGroup>
    //<!--Publish copies the untransformed App.config to deployment directory so overwrite it-->
    //<Copy Condition = "Exists('$(DeployedConfig)')" SourceFiles="$(IntermediateOutputPath)$(TargetFileName).config" DestinationFiles="$(DeployedConfig)" />
    //</Target>

    public class DeploymentConfiguration
    {
        public string DeployedConfig { get; }
        public string CopyCondition { get; }
        public string CopySourceFiles { get; }
        public string CopyDestinationFiles { get; }

        public DeploymentConfiguration(
            string deployedConfig,
            string copyCondition,
            string copySourceFiles,
            string copyDestinationFiles)
        {
            DeployedConfig = deployedConfig;
            CopyCondition = copyCondition;
            CopySourceFiles = copySourceFiles;
            CopyDestinationFiles = copyDestinationFiles;
        }
    }
}

