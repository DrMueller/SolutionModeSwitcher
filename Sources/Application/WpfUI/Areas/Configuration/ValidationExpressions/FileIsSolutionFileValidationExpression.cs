using System.Globalization;
using Mmu.Sms.Common.Ioc;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models;

namespace Mmu.Sms.WpfUI.Areas.Configuration.ValidationExpressions
{
    public class FileIsSolutionFileValidationExpression : IValidationExpression
    {
        public ValidationResult Validate(object value)
        {
            var pathProxy = ProvisioningServiceSingleton.Instance.GetService<IPathProxy>();
            var str = value?.ToString();

            if (pathProxy.GetExtension(str).ToUpperInvariant()!= ".SLN")
            {
                return ValidationResult.CreateInvalid("File is not of type '.sln'.");
            }

            return ValidationResult.CreateValid();
        }
    }
}