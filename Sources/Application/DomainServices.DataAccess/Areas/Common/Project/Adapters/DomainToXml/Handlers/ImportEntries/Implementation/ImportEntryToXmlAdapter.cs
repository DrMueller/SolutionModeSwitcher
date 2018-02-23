using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Models.ElementTypes;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.ImportEntries.Implementation
{
    public class ImportEntryToXmlAdapter : IImportEntryToXmlAdapter
    {
        private readonly IXmlWritingService _xmlWritingService;

        public ImportEntryToXmlAdapter(IXmlWritingService xmlWritingService)
        {
            _xmlWritingService = xmlWritingService;
        }

        public IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = projectConfigFile.ImportEntries.Select(AdaptElement).ToList();

            return result;
        }

        private XElement AdaptElement(ImportEntry importEntry)
        {
            var result = new XElement("Import");
            _xmlWritingService.ConditionallyAdd(ObjectType.Attribute, result, "Project", importEntry.RelativeProjectPath);
            _xmlWritingService.ConditionallyAdd(ObjectType.Attribute, result, "Condition", importEntry.Condition);

            return result;
        }
    }
}