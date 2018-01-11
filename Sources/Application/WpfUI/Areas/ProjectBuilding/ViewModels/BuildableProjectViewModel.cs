using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Sms.Common.LanguageExtensions.Proxies;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public class BuildableProjectViewModel : ViewModelBase
    {
        private readonly IPathProxy _pathProxy;
        private readonly IProjectBuildStateFactory _projectBuildStateFactory;
        private IProjectBuildState _projectState;

        public BuildableProjectViewModel(IPathProxy pathProxy, IProjectBuildStateFactory projectBuildStateFactory)
        {
            _pathProxy = pathProxy;
            _projectBuildStateFactory = projectBuildStateFactory;
        }

        public ICommand BuildProjectCommand
        {
            get
            {
                return new RelayCommand( 
                    async () =>
                    {
                        await BuildProjectAsync();
                    });
            }
        }

        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string ImageSource => _projectState.ImageSource;
        public bool IsBuildInProgress => _projectState.IsBuildInProgress;
        public bool IsTooltipVisible => _projectState.IsTooltipVisible;
        public string TooltipText => _projectState.TooltipText;

        private IProjectBuildState ProjectBuildState
        {
            set
            {
                _projectState = value;
                OnPropertyChanged(nameof(ImageSource));
                OnPropertyChanged(nameof(IsBuildInProgress));
                OnPropertyChanged(nameof(TooltipText));
                OnPropertyChanged(nameof(IsTooltipVisible));
            }
        }

        public async Task BuildProjectAsync()
        {
            await _projectState.StartBuildingAsync(FilePath, ProjectBuildStateChanged);
        }

        public void Initialize(string filePath)
        {
            FilePath = filePath;
            FileName = _pathProxy.GetFileName(filePath);
            _projectState = _projectBuildStateFactory.CreateReadyToBuildState();
        }

        private void ProjectBuildStateChanged(IProjectBuildState newState)
        {
            ProjectBuildState = newState;
        }
    }
}