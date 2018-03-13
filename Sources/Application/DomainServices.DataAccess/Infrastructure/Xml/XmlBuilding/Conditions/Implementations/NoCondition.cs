namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions.Implementations
{
    public class NoCondition : XmlBuildingCondition
    {
        public override bool CheckIfSatisfiedBy(object value)
        {
            return true;
        }
    }
}