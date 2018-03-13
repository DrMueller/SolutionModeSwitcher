using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.SlowCheetah;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.SlowCheetah
{
    public interface ISlowCheetahConfigurationAdapter
    {
        Maybe<SlowCheetahConfiguration> Adapt(XDocument document);
    }
}