using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mmu.Sms.Application.Areas.App.Informations.Models;
using Mmu.Sms.Application.Areas.App.Informations.Services;
using Mmu.Sms.Application.Areas.Domain.Confguration.Dtos;
using Mmu.Sms.WpfUI.Areas.Configuration.Services;
using Mmu.Sms.WpfUI.Infrastructure.Services.Threading;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.TopLevel;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Areas.ModeSwitching
{
    public sealed class SolutionModeSwitchingViewModel : TopLevelViewModelBase, IMainNavigationViewModel
    {
        private readonly SolutionModeSwitchingCommandsContainer _commandsContainer;
        private readonly IConfigurationService _configurationService;
        private readonly IThreadingService _threadingService;
        private IReadOnlyCollection<SolutionModeConfigurationDto> _configurations;

        public SolutionModeSwitchingViewModel(
            SolutionModeSwitchingCommandsContainer commandsContainer,
            IConfigurationService configurationService,
            IInformationConfigurationService informationConfigurationService,
            IThreadingService threadingService)
        {
            _configurationService = configurationService;
            _threadingService = threadingService;
            DisplayName = "Solution Mode Switching";
            Informations = new ObservableCollection<Information>();

            _commandsContainer = commandsContainer;
            _commandsContainer.Initialize(this);
            informationConfigurationService.RegisterForAllTypes(InformationReceived);
        }

        public IReadOnlyCollection<SolutionModeConfigurationDto> Configurations
        {
            get => _configurations;
            set
            {
                _configurations = value;
                OnPropertyChanged();
            }
        }

        public override string DisplayName { get; protected set; }
        public IViewModelCommand DoRevertSwitch => _commandsContainer.DoRevertSwitch;
        public IViewModelCommand DoSwitch => _commandsContainer.DoSwitch;
        public ObservableCollection<Information> Informations { get; set; }
        public string NavigationDescription => "Switching";
        public int NavigationSequence => 1;
        public SolutionModeConfigurationDto SelectedConfiguration { get; set; }

        public override void OnInit()
        {
            Configurations = _configurationService.LoadAllConfigurations();
        }

        private void InformationReceived(Information information)
        {
            _threadingService.InvokeOnUiThread(
                () =>
                {
                    Informations.Insert(0, information);
                });
        }
    }
}