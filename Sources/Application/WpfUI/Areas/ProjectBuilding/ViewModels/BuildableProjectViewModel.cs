using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates;
using Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels.ProjectBuildStates.Implementation;
using Mmu.Sms.WpfUI.Infrastructure.Wpf.Commands;
using Mmu.Sms.WpfUI.Properties;

namespace Mmu.Sms.WpfUI.Areas.ProjectBuilding.ViewModels
{
    public class BuildableProjectViewModel : INotifyPropertyChanged
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ProjectBuildStateChanged(IProjectBuildState newState)
        {
            ProjectBuildState = newState;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}