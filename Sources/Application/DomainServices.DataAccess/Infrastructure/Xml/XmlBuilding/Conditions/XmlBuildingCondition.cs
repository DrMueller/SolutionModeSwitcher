using Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions.Implementations;

namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.Xml.XmlBuilding.Conditions
{
    public abstract class XmlBuildingCondition
    {
        public static XmlBuildingCondition None = new NoCondition();
        public static XmlBuildingCondition NotNullOrEmpty = new NotNullOrEmptyCondition();
        public static XmlBuildingCondition NotNull = new NotNullOrEmptyCondition();

        public abstract bool CheckIfSatisfiedBy(object value);
    }
}