using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models;

namespace Mmu.Sms.WpfUI.Areas.Common.ValidationExpressions
{
    public class StringNotNullOrEmptyValidationExpression : IValidationExpression
    {
        public ValidationResult Validate(object value)
        {
            var str = value?.ToString();

            if (string.IsNullOrEmpty(str))
            {
                return ValidationResult.CreateInvalid("String must not be null or empty.");
            }

            return ValidationResult.CreateValid();
        }
    }
}