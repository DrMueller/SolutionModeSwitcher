using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.ImportEntries;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ImportEntries.Implementation
{
    public class ImportEntryToXmlAdapter : IImportEntryToXmlAdapter
    {
        private readonly IXmlElementBuilderFactory _elementBuilderFactory;

        public ImportEntryToXmlAdapter(IXmlElementBuilderFactory elementBuilderFactory)
        {
            _elementBuilderFactory = elementBuilderFactory;
        }

        public IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.ImportEntries.Select(AdaptElement).ToList();

            return result;
        }

        private XElement AdaptElement(ImportEntry importEntry)
        {
            var elementBuilder = _elementBuilderFactory.CreateTopLevelElement("Import");

            var result =
                elementBuilder
                    .WithAttribute("Project")
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .WithAttributeValue(importEntry.RelativeProjectPath)
                    .BuildAttribute()
                    .WithAttribute("Condition")
                    .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                    .WithAttributeValue(importEntry.Condition)
                    .BuildAttribute()
                    .FinishBuilding();

            return result;
        }
    }
}