using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ImportEntry.Implementation
{
    public class XmlToImportEntryAdapter : IXmlToImportEntryAdapter
    {
        public IReadOnlyCollection<Domain.Areas.Common.Project.ImportEntry> Adapt(XDocument document)
        {
            var result = new List<Domain.Areas.Common.Project.ImportEntry>();
            var importNodes = document.Descendants().Where(f => f.Name.LocalName == "Import");

            foreach (var importNode in importNodes)
            {
                var condition = importNode.Attributes().FirstOrDefault(f => f.Name == "Condition")?.Value ?? string.Empty;
                var relativeProjectPath = importNode.Attributes().First(f => f.Name == "Project").Value;

                var importEntry = new Domain.Areas.Common.Project.ImportEntry(condition, relativeProjectPath);
                result.Add(importEntry);
            }

            return result;
        }
    }
}