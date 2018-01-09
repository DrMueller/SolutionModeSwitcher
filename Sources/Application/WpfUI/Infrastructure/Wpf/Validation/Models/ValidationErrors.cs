using System.Collections.Generic;
using System.Linq;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models
{
    public class ValidationErrors
    {
        private readonly List<string> _propertiesWithErrors;

        public ValidationErrors()
        {
            _propertiesWithErrors = new List<string>();
        }

        public bool HasErrors => _propertiesWithErrors.Any();

        public void UpdateErrors(string propertyName, IReadOnlyCollection<string> invalidResultErrorMessages)
        {
            if (invalidResultErrorMessages.Any() && !_propertiesWithErrors.Contains(propertyName))
            {
                _propertiesWithErrors.Add(propertyName);
            }

            if (!invalidResultErrorMessages.Any())
            {
                _propertiesWithErrors.Remove(propertyName);
            }
        }
    }
}