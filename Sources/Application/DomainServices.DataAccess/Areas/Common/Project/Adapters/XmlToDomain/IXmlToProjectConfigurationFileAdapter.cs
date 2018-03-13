using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain
{
    public interface IXmlToProjectConfigurationFileAdapter
    {
        ProjectConfigurationFile Adapt(string filePath);
    }
}