using System.Windows.Input;
using Mmu.Sms.Application.Areas.Domain.ModeSwitching.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Exceptions;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ModeSwitching.ViewModelCommands
{
    public class DoRevertSwitchViewModelCommand : IInitializableViewModelCommand<SolutionModeSwitchingViewModel>
    {
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly ISolutionSwitchingService _solutionSwitchingService;
        private SolutionModeSwitchingViewModel _context;

        public DoRevertSwitchViewModelCommand(IExceptionHandlingService exceptionHandlingService, ISolutionSwitchingService solutionSwitchingService)
        {
            _exceptionHandlingService = exceptionHandlingService;
            _solutionSwitchingService = solutionSwitchingService;
        }

        public ICommand Command => CreateDoRevertSwitchCommand();
        public string Description => "Revert";

        public void Initialize(SolutionModeSwitchingViewModel context)
        {
            _context = context;
        }

        private bool CheckIfCanDoRevertSwitch()
        {
            return _context.SelectedConfiguration != null;
        }

        private ICommand CreateDoRevertSwitchCommand()
        {
            return new RelayCommand(DoRevertSwitch, CheckIfCanDoRevertSwitch);
        }

        private void DoRevertSwitch()
        {
            _exceptionHandlingService.HandledAction(
                () =>
                {
                    _solutionSwitchingService.RevertSwitch(_context.SelectedConfiguration);
                });
        }
    }
}