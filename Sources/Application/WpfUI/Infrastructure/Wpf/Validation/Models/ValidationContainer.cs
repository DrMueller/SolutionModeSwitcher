using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models
{
    public class ValidationContainer
    {
        private readonly EventHandler<DataErrorsChangedEventArgs> _errorsChanged;
        private readonly ViewModelBase _viewModel;
        private PropertyValidationsContainer _propertyValidationsContainer;

        public ValidationContainer(EventHandler<DataErrorsChangedEventArgs> errorsChanged, ViewModelBase viewModel)
        {
            _errorsChanged = errorsChanged;
            _viewModel = viewModel;
            _propertyValidationsContainer = new PropertyValidationsContainer();
        }

        public bool HasErrors => _propertyValidationsContainer.HasErrors;

        public void AddValidation(string propertyName, IValidationExpression expression)
        {
            _propertyValidationsContainer.AddExpressionForProperty(propertyName, expression);
        }

        public IReadOnlyCollection<string> GetErrorMessages(string propertyName)
        {
            var propertyValue = _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel);
            var validationErrorMessages = _propertyValidationsContainer.GetValidationErrorMessages(propertyName, propertyValue);
            return validationErrorMessages;
        }

        public void Validate([CallerMemberName] string propertyName = null)
        {
            if (GetErrorMessages(propertyName).Any())
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            _errorsChanged?.Invoke(_viewModel, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}