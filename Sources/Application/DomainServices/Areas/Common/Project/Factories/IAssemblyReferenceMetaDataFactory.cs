using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IAssemblyReferenceMetaDataFactory
    {
        string CreateHintPath(string relativeProjectFileIncludePath, ProjectConfigurationFile projectConfig);

        IncludeDefinition CreateIncludeDefinition(string assemblyFileName);
    }
}