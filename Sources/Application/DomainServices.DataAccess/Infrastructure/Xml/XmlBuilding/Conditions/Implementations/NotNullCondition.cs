namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions.Implementations
{
    public class NotNullCondition : XmlBuildingCondition
    {
        public override bool CheckIfSatisfiedBy(object value)
        {
            return value != null;
        }
    }
}