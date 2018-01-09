using System.Windows.Input;

namespace Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels
{
    public class ViewModelCommand
    {
        public ViewModelCommand(string description, ICommand command)
        {
            Description = description;
            Command = command;
        }

        public ICommand Command { get; private set; }
        public string Description { get; private set; }
    }
}