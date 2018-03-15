using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Sms.WpfUI.Infrastructure.Services.Navigation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.Factories;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels.ViewModelBehaviors;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.MainNavigation.Initialization.Implementation
{
    public class MainNavigationInitializingService : IMainNavigationInitializingService
    {
        private readonly INavigationService _navigationService;
        private readonly ITopLevelViewModelFactory _topLevelViewModelFactory;
        private IReadOnlyCollection<ViewModelCommand> _navigationViewModelCommands;

        public MainNavigationInitializingService(INavigationService navigationService, ITopLevelViewModelFactory topLevelViewModelFactory)
        {
            _navigationService = navigationService;
            _topLevelViewModelFactory = topLevelViewModelFactory;
        }

        public IReadOnlyCollection<ViewModelCommand> GetOrderedMainNavigationEntries()
        {
            AssureNavigationIsInitialized();
            return _navigationViewModelCommands;
        }

        public void NavigateToMainEntryPoint()
        {
            AssureNavigationIsInitialized();
            var mainEntry = _navigationViewModelCommands.FirstOrDefault();
            mainEntry?.Command.Execute(null);
        }

        private void AssureNavigationIsInitialized()
        {
            if (_navigationViewModelCommands == null)
            {
                _navigationViewModelCommands = CreateOrderedNavigationViewModels();
            }
        }

        private IReadOnlyCollection<ViewModelCommand> CreateOrderedNavigationViewModels()
        {
            var viewModelsDict = new Dictionary<int, ViewModelCommand>();
            var navigatableViewModels = GetNavigatableViewModels();

            foreach (var navigatableViewModel in navigatableViewModels)
            {
                var navigatableInterface = (IMainNavigationViewModel)navigatableViewModel;
                var vmc = new ViewModelCommand(
                    navigatableInterface.NavigationDescription,
                    new RelayCommand(
                        () =>
                        {
                            _navigationService.NavigateTo(navigatableViewModel);
                        }));

                viewModelsDict.Add(navigatableInterface.NavigationSequence, vmc);
            }

            var result = viewModelsDict.OrderBy(f => f.Key).Select(f => f.Value).ToList();
            return result.AsReadOnly();
        }

        private IEnumerable<TopLevelViewModelBase> GetNavigatableViewModels()
        {
            var navigatableTypes = GetNavigatableViewModelTypes();
            var result = navigatableTypes.Select(
                f =>
                {
                    var vm = _topLevelViewModelFactory.CreateViewModel(f);
                    return vm;
                });

            return result;
        }

        private static IEnumerable<Type> GetNavigatableViewModelTypes()
        {
            var navigatableType = typeof(IMainNavigationViewModel);
            var viewModelbaseType = typeof(ViewModelBase);

            var result = navigatableType.Assembly.GetTypes().Where(f => navigatableType.IsAssignableFrom(f) && viewModelbaseType.IsAssignableFrom(f));
            return result.ToList();
        }
    }
}