using Mmu.Sms.WpfUI.Infrastructure.Services.FileDialog.Models;

namespace Mmu.Sms.WpfUI.Infrastructure.Services.FileDialog.Services
{
    public interface IFileDialogService
    {
        FileDialogResult SelectFileName(string filter);
    }
}