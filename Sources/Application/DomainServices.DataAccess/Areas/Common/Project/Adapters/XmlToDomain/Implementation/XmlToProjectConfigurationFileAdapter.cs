using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Implementation
{
    public class XmlToProjectConfigurationFileAdapter : IXmlToProjectConfigurationFileAdapter
    {
        private readonly IXmlToImportEntryAdapter _importEntryAdapter;

        public XmlToProjectConfigurationFileAdapter(IXmlToImportEntryAdapter importEntryAdapter)
        {
            _importEntryAdapter = importEntryAdapter;
        }

        public ProjectConfigurationFile Adapt(string filePath)
        {
            var document = XDocument.Load(filePath);
            var importEntries = _importEntryAdapter.Adapt(document);
            var result = new ProjectConfigurationFile(filePath, importEntries);

            return result;
        }
    }
}
