using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces
{
    public interface IValidationExpression
    {
        ValidationResult Validate(object value);
    }
}