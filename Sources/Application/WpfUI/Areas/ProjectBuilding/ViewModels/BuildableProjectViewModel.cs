using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models.ProjectStates;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.Models.ProjectStates.Implementation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Shell.ViewModels;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public class BuildableProjectViewModel : ViewModelBase
    {
        private readonly Func<string, Task> _buildRequestedCallback;
        private IProjectBuildState _projectState;

        public BuildableProjectViewModel(string filePath, string fileName, Func<string, Task> buildRequestedCallback)
        {
            _buildRequestedCallback = buildRequestedCallback;
            FilePath = filePath;
            FileName = fileName;
            _projectState = new ReadyToBuildState();
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

        public string FileName { get; }
        public string FilePath { get; }
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
            await _projectState.StartBuildingAsync(
                FilePath,
                _buildRequestedCallback,
                ProjectBuildStateChanged);
        }

        private void ProjectBuildStateChanged(IProjectBuildState newState)
        {
            ProjectBuildState = newState;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}