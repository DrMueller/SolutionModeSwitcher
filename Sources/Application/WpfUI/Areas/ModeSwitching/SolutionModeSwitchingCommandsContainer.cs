using Mmu.Sms.WpfUI.Areas.ModeSwitching.ViewModelCommands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ModeSwitching
{
    public class SolutionModeSwitchingCommandsContainer : IViewModelCommandsContainer<SolutionModeSwitchingViewModel>
    {
        public SolutionModeSwitchingCommandsContainer(DoSwitchViewModelCommand doSwitch, DoRevertSwitchViewModelCommand doRevertSwitch)
        {
            DoSwitch = doSwitch;
            DoRevertSwitch = doRevertSwitch;
        }

        public void Initialize(SolutionModeSwitchingViewModel context)
        {
            DoRevertSwitch.Initialize(context);
            DoSwitch.Initialize(context);
        }

        public DoSwitchViewModelCommand DoSwitch { get; }
        public DoRevertSwitchViewModelCommand DoRevertSwitch { get; }
    }
}
