using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IAssemblyReferenceFromProjectReferenceFactory
    {
        ProjectAssemblyReference CreateFromProjectReferenceFilePath(string projectReferenceFilePath, string relativeIncludePath);
    }
}