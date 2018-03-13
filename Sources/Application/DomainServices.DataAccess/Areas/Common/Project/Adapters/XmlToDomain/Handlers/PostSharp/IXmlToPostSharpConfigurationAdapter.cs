using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project.PostSharp;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.PostSharp
{
    public interface IXmlToPostSharpConfigurationAdapter
    {
        Maybe<PostSharpConfiguration> Adapt(XDocument document);
    }
}