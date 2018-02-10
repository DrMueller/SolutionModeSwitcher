using System;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project.Inclusions.FileInclusions;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Inclusions.Implementation
{
    public class BuildActionAdapter : IBuildActionAdapter
    {
        public BuildAction Adapt(XElement element)
        {
            switch (element.Name.LocalName)
            {
                case "Content":
                {
                    return BuildAction.Content;
                }
                case "Compile":
                {
                    return BuildAction.Compile;
                }

                case "EmbeddedResource":
                {
                    return BuildAction.EmbeddedResource;
                }

                case "CodeAnalysisDictionary":
                {
                    return BuildAction.CodeAnalysisDictionary;
                }
                default:
                {
                    throw new NotImplementedException(element.Name.LocalName);
                }
            }
        }
    }
}