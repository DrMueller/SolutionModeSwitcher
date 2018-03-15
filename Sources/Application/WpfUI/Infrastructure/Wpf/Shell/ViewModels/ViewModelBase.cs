using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Interfaces;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Validation.Models;
using Mmu.Sms.WpfUI.Properties;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly ValidationContainer _validationContainer;

        protected ViewModelBase()
        {
            _validationContainer = new ValidationContainer(ErrorsChanged, this);
        }

        public bool HasErrors => _validationContainer.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _validationContainer.GetErrorMessages(propertyName);
        }

        public virtual void OnInit()
        {
        }

        protected void AddValidation(string propertyName, IValidationExpression expression)
        {
            _validationContainer.AddValidation(propertyName, expression);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            _validationContainer.Validate(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}