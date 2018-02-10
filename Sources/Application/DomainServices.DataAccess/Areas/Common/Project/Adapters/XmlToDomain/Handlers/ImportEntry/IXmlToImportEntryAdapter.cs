using System.Collections.Generic;
using System.Xml.Linq;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.ImportEntry
{
    public interface IXmlToImportEntryAdapter
    {
        IReadOnlyCollection<Domain.Areas.Common.Project.ImportEntry> Adapt(XDocument document);
    }
}