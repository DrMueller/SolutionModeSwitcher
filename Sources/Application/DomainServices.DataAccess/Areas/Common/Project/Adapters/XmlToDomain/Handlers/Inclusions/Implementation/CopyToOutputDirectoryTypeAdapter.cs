using System;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlReading;

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

                case "PreserveNewest":
                {
                    return CopyToOutputDirectoryType.PreserveNewest;
                }

                case "DoNotCopy":
                {
                    return CopyToOutputDirectoryType.DoNotCopy;
                }

                case "None":
                {
                    return CopyToOutputDirectoryType.None;
                }


                default:
                {
                    throw new Exception("Copy to output type: " + copyToOutputValue);
                }
            }
        }
    }
}