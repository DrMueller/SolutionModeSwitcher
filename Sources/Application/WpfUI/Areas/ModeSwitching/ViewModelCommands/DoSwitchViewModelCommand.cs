using System.Windows.Input;
using Mmu.Sms.Application.Areas.Domain.ModeSwitching.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ModeSwitching.ViewModelCommands
{
    public class DoSwitchViewModelCommand : IInitializableViewModelCommand<SolutionModeSwitchingViewModel>
    {
        private readonly IExceptionHandlingService _exceptionHandler;
        private readonly ISolutionSwitchingService _solutionSwitchingService;
        private SolutionModeSwitchingViewModel _context;

        public DoSwitchViewModelCommand(IExceptionHandlingService exceptionHandler, ISolutionSwitchingService solutionSwitchingService)
        {
            _exceptionHandler = exceptionHandler;
            _solutionSwitchingService = solutionSwitchingService;
        }

        public ICommand Command => CreateDoSwitchCommand();
        public string Description => "Switch";

        public void Initialize(SolutionModeSwitchingViewModel context)
        {
            _context = context;
        }

        private bool CheckIfCanDoSwitch()
        {
            return _context.SelectedConfiguration != null;
        }

        private ICommand CreateDoSwitchCommand()
        {
            return new RelayCommand(DoSwitch, CheckIfCanDoSwitch);
        }

        private void DoSwitch()
        {
            _exceptionHandler.HandledAction(
                () =>
                {
                    _context.Informations.Clear();
                    _solutionSwitchingService.SwitchSolution(_context.SelectedConfiguration);
                });
        }
    }
}