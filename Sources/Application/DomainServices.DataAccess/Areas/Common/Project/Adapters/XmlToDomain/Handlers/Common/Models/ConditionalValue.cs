namespace Mmu.Sms.DomainServices.DataAccess.Areas.Common.Project.Adapters.XmlToDomain.Handlers.Common.Models
{
    public class ConditionalValue<TValue>
    {
        public ConditionalValue(string condition, TValue value)
        {
            Condition = condition;
            Value = value;
        }

        public string Condition { get; }
        public TValue Value { get; }
    }
}