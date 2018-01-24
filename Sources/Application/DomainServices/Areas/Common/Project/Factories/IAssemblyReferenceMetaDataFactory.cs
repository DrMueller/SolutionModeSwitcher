using Mmu.Sms.Domain.Areas.Common._LegacyProject;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories
{
    public interface IAssemblyReferenceMetaDataFactory
    {
        string CreateHintPath(string relativeProjectFileIncludePath, Domain.Areas.Common.Project.ProjectConfigurationFile projectConfig);

        IncludeDefinition CreateIncludeDefinition(string assemblyFileName);
    }
}