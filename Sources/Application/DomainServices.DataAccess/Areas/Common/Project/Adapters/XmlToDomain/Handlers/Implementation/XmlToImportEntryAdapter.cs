using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Implementation
{
    public class XmlToImportEntryAdapter : IXmlToImportEntryAdapter
    {
        public IReadOnlyCollection<ImportEntry> Adapt(XDocument document)
        {
            var result = new List<ImportEntry>();
            var importNodes = document.Descendants().Where(f => f.Name.LocalName == "Import");

            foreach (var importNode in importNodes)
            {
                var relativePath = importNode.Attribute("Project")?.Value;
                var condition = importNode.Attribute("Condition")?.Value;

                var importEntry = new ImportEntry(relativePath, condition);
                result.Add(importEntry);
            }

            return result;
        }
    }
}