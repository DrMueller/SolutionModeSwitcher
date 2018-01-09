using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.Areas.Common.Project.Factories.SubFactories
{
    public interface IAssemblyReferenceMetaDataFactory
    {
        string CreateHintPath(string relativeProjectFileIncludePath, ProjectConfigurationFile projectConfig);

        IncludeDefinition CreateIncludeDefinition(string assemblyFileName);
    }
}