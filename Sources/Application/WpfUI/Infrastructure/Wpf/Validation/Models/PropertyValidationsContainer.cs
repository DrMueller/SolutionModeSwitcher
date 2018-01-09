using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models
{
    public class PropertyValidationsContainer
    {
        private readonly List<PropertyValidation> _entries;
        private readonly ValidationErrors _validationErrors;

        public PropertyValidationsContainer()
        {
            _entries = new List<PropertyValidation>();
            _validationErrors = new ValidationErrors();
        }

        public bool HasErrors => _validationErrors.HasErrors;

        public void AddExpressionForProperty(string propertyName, IValidationExpression expression)
        {
            _entries.Add(new PropertyValidation(propertyName, expression));
        }

        public IReadOnlyCollection<string> GetValidationErrorMessages(string propertyName, object value)
        {
            var propertyValidations = _entries.Where(f => f.PropertyName == propertyName);
            var validationResults = propertyValidations.Select(f => f.Validate(value)).ToList();
            var invalidResultErrorMessages = validationResults.Where(f => !f.IsValid).Select(f => f.ErrorMessage).ToList();
            _validationErrors.UpdateErrors(propertyName, invalidResultErrorMessages);
            return invalidResultErrorMessages;
        }
    }
}