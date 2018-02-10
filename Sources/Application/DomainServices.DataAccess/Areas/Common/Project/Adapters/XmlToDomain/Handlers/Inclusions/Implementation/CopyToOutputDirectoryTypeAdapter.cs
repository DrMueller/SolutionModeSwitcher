using System;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions.Implementation
{
    public class CopyToOutputDirectoryTypeAdapter : ICopyToOutputDirectoryTypeAdapter
    {
        private readonly IXmlParsingService _xmlParsingService;

        public CopyToOutputDirectoryTypeAdapter(IXmlParsingService xmlParsingService)
        {
            _xmlParsingService = xmlParsingService;
        }

        public CopyToOutputDirectoryType Adapt(XElement element)
        {
            var copyToOutputValue = _xmlParsingService.TryParsingSubElementStringValue(element, "CopyToOutputDirectory");

            if (string.IsNullOrEmpty(copyToOutputValue))
            {
                return CopyToOutputDirectoryType.None;
            }

            switch (copyToOutputValue)
            {
                case "Always":
                {
                    return CopyToOutputDirectoryType.CopyAlways;
                }

                case "CopyToOutputDirectory":
                {
                    return CopyToOutputDirectoryType.PreserveNewest;
                }

                case "DoNotCopy":
                {
                    return CopyToOutputDirectoryType.DoNotCopy;
                }

                default:
                {
                    throw new Exception(copyToOutputValue);
                }
            }
        }
    }
}