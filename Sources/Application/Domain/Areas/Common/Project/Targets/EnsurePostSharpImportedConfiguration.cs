using System.Collections.Generic;

namespace Mmu.Sms.Domain.Areas.Common.Project.Targets
{
//<Target Name = "EnsurePostSharpImported" BeforeTargets="BeforeBuild" Condition="'$(PostSharp30Imported)' == ''">
//<Error Condition = "!Exists('..\..\..\..\packages\PostSharp.4.2.14\tools\PostSharp.targets')" Text="This project references NuGet package(s) that are missing on this computer. Enable NuGet Package Restore to download them.  For more information, see http://www.postsharp.net/links/nuget-restore." />
//<Error Condition = "Exists('..\..\..\..\packages\PostSharp.4.2.14\tools\PostSharp.targets')" Text="The build restored NuGet packages. Build the project again to include these packages in the build. For more information, see http://www.postsharp.net/links/nuget-restore." />
//</Target>

    public class EnsurePostSharpImportedConfiguration
    {
        public EnsurePostSharpImportedConfiguration(string beforeTargets, string condition, IReadOnlyCollection<TargetError> targetErrors)
        {
            BeforeTargets = beforeTargets;
            Condition = condition;
            TargetErrors = targetErrors;
        }

        public string BeforeTargets { get; }
        public string Condition { get; }
        public IReadOnlyCollection<TargetError> TargetErrors { get; }
    }
}