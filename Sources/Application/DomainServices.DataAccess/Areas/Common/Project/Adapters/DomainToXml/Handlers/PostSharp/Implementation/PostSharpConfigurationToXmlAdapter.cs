using System.Xml.Linq;
using Mmu.Sms.Common.LanguageExtensions.Maybes;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.PostSharp.Implementation
{
    public class PostSharpConfigurationToXmlAdapter : IPostSharpConfigurationToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuildFactory;

        public PostSharpConfigurationToXmlAdapter(IXmlElementBuilderFactory xmlElementBuildFactory)
        {
            _xmlElementBuildFactory = xmlElementBuildFactory;
        }

        public Maybe<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.PostSharpConfiguration.Evaluate(
                config =>
                {
                    var element = _xmlElementBuildFactory.CreateTopLevelElement("PropertyGroup")
                        .StartBuildingChildElement("PostSharpHostConfigurationFile")
                        .WithElementValue(config.PostSharpHostConfigurationFile)
                        .BuildElement()
                        .FinishBuilding();

                    return MaybeFactory.CreateSome(element);
                },
                MaybeFactory.CreateNone<XElement>);

            return result;
        }
    }
}