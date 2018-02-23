using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ImportEntries
{
    public interface IXmlToImportEntryAdapter
    {
        IReadOnlyCollection<ImportEntry> Adapt(XDocument document);
    }
}