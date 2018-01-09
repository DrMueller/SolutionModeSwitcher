using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ValidationExpressions
{
    public class FileExistsValidationExpression : IValidationExpression
    {
        public ValidationResult Validate(object value)
        {
            var fileProxy = ProvisioningServiceSingleton.Instance.GetService<IFileProxy>();
            var str = value?.ToString();

            if (!fileProxy.Exists(str))
            {
                return ValidationResult.CreateInvalid("File does not exist.");
            }

            return ValidationResult.CreateValid();
        }
    }
}