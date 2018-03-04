using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IAssemblyReferenceFromProjectReferenceFactory
    {
        ProjectAssemblyReference CreateFromProjectReferenceFilePath(string projectReferenceFilePath, string relativeIncludePath);
    }
}