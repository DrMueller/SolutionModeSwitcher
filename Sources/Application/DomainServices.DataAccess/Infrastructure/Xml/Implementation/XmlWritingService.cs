using System;
using System.Xml.Linq;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Models.ElementTypes;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.Implementation
{
    public class XmlWritingService : IXmlWritingService
    {
        public void ConditionallyAdd<T>(ObjectType objectType, XElement targetElement, string name, T value)
        {
            if (CheckIfCanWrite(value))
            {
                objectType.WriteContent(targetElement, name, value);
            }
        }

        private static bool CheckIfCanWrite<T>(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            if (str != null)
            {
                return !string.IsNullOrEmpty(str);
            }

            throw new Exception("CheckIfCanWrite " + value);
        }
    }
}