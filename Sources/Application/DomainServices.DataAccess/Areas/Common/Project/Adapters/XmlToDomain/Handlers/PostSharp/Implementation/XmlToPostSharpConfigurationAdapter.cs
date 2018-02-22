using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.PostSharp.Implementation
{
    public class XmlToPostSharpConfigurationAdapter : IXmlToPostSharpConfigurationAdapter
    {
        public Maybe<PostSharpConfiguration> Adapt(XDocument document)
        {
            var postSharpHostConfigFileElement = document.Descendants().FirstOrDefault(f => f.Name.LocalName == "PostSharpHostConfigurationFile");
            PostSharpConfiguration config = null;

            if (postSharpHostConfigFileElement != null)
            {
                var configHostFileValue = postSharpHostConfigFileElement.Value;
                config = new PostSharpConfiguration(configHostFileValue);
            }

            return MaybeFactory.CreateFromNullable(config);
        }
    }
}