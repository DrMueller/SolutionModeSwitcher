using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IAssemblyReferenceFromProjectReferenceFactory
    {
        ProjectAssemblyReference CreateFromProjectReferenceFilePath(string projectReferenceFilePath, string relativeIncludePath);
    }
}