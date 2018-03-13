using System.Text;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.AssemblyReferences;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.AssemblyReferences.Implementation
{
    public class AssemblyReferenceToXmlAdapter : IAssemblyReferenceToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public AssemblyReferenceToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
        }

        public XElement Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var builder = _xmlElementBuilderFactory.CreateTopLevelElement("ItemGroup");

            foreach (var assemblyReference in projectConfigFile.AssemblyReferences)
            {
                builder.StartBuildingChildElement("Reference")
                    .WithAttribute("Include")
                    .WithAttributeValue(CreateAttributeValueFromIncludeDefinition(assemblyReference.IncludeDefinition))
                    .BuildAttribute()
                    .StartBuildingChildElement("SpecificVersion")
                    .WithElementValue(assemblyReference.SpecificVersion)
                    .WithCondition(XmlBuildingCondition.NotNull)
                    .BuildElement()
                    .StartBuildingChildElement("HintPath")
                    .WithElementValue(assemblyReference.HintPath)
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .BuildElement()
                    .StartBuildingChildElement("Private")
                    .WithElementValue(assemblyReference.IsPrivate)
                    .WithCondition(XmlBuildingCondition.NotNull)
                    .BuildElement()
                    .BuildElement();
            }

            var result = builder.FinishBuilding();
            return result;
        }

        private static void AppendCommaSeperatedIfNotNullOrEmpty(StringBuilder sb, string prefix, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var str = ", " + prefix + value;
            sb.Append(str);
        }

        private static string CreateAttributeValueFromIncludeDefinition(IncludeDefinition includeDefinition)
        {
            var sb = new StringBuilder();
            sb.Append(includeDefinition.ShortName);
            AppendCommaSeperatedIfNotNullOrEmpty(sb, "Version=", includeDefinition.Version);
            AppendCommaSeperatedIfNotNullOrEmpty(sb, "Culture=", includeDefinition.Culture);
            AppendCommaSeperatedIfNotNullOrEmpty(sb, "PublicKeyToken=", includeDefinition.PublicKeyToken);
            AppendCommaSeperatedIfNotNullOrEmpty(sb, "processorArchitecture=", includeDefinition.ProcessorArchitecture);

            var result = sb.ToString();
            return result;
        }
    }
}