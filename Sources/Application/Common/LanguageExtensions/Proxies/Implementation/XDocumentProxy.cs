using System.Xml.Linq;

namespace Mmu.Sms.Common.LanguageExtensions.Proxies.Implementation
{
    public class XDocumentProxy : IXDocumentProxy
    {
        private readonly XDocument _document;

        public XDocumentProxy(XDocument document)
        {
            _document = document;
        }

        public void Save(string fileName)
        {
            _document.Save(fileName);
        }
    }
}