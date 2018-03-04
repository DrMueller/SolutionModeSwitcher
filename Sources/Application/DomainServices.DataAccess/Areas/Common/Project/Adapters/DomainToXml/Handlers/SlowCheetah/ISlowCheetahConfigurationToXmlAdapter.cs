using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.SlowCheetah
{
    public interface ISlowCheetahConfigurationToXmlAdapter
    {
        Maybe<XElement> Adapt(ProjectConfigurationFile projectConfigFile);
    }
}