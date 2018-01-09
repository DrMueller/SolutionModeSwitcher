using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models
{
    public class PropertyValidation
    {
        private readonly IValidationExpression _expression;

        public PropertyValidation(string propertyName, IValidationExpression expression)
        {
            _expression = expression;
            PropertyName = propertyName;
            PropertyName = propertyName;
        }

        public string PropertyName { get; }

        public ValidationResult Validate(object value)
        {
            return _expression.Validate(value);
        }
    }
}