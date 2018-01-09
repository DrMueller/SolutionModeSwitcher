using Microsoft.Win32;
using Mmu.Sms.WpfUI.Infrastructure.Services.FileDialog.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.FileDialog.Services.Implementation
{
    public class FileDialogService : IFileDialogService
    {
        public FileDialogResult SelectFileName(string filter)
        {
            var openFileDialog = new OpenFileDialog { Filter = filter };

            if (openFileDialog.ShowDialog() == true)
            {
                return new FileDialogResult(true, openFileDialog.FileName);
            }

            return new FileDialogResult(false, string.Empty);
        }
    }
}