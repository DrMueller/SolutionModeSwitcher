using System.Collections.Generic;
using System.Xml.Linq;
using Mmu.Sms.Domain.Areas.Common.Project;
using Mmu.Sms.Domain.Areas.Common.Project.Targets;
using Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Targets.Handlers;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions;
using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Factories;

namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.DomainToXml.Handlers.Targets.Implementation
{
    public class TargetToXmlAdapter : ITargetToXmlAdapter
    {
        private readonly IGenericElementToXmlAdapter _genericElementAdapter;
        private readonly IXmlElementBuilderFactory _xmlElementBuilderFactory;

        public TargetToXmlAdapter(IXmlElementBuilderFactory xmlElementBuilderFactory, IGenericElementToXmlAdapter genericElementAdapter)
        {
            _xmlElementBuilderFactory = xmlElementBuilderFactory;
            _genericElementAdapter = genericElementAdapter;
        }

        public IReadOnlyCollection<XElement> Adapt(ProjectConfigurationFile projectConfigFile)
        {
            var result = new List<XElement>();

            foreach (var target in projectConfigFile.Targets)
            {
                var element = BuildTargetElement(target);
                foreach (var subElement in target.Elements)
                {
                    element.Add(_genericElementAdapter.Adapt(subElement));
                }

                result.Add(element);
            }

            return result;
        }

        private XElement BuildTargetElement(Target target)
        {
            var result = _xmlElementBuilderFactory.CreateTopLevelElement("Target")
                .WithAttribute("Name")
                .WithAttributeValue(target.Name)
                .BuildAttribute()
                .WithAttribute("BeforeTargets")
                .WithAttributeValue(target.BeforeTargets)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildAttribute()
                .WithAttribute("Condition")
                .WithAttributeValue(target.Condition)
                .WithCondition(XmlBuildingCondition.NotNullOrEmpty)
                .BuildAttribute()
                .FinishBuilding();

            return result;
        }
    }
}