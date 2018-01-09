using System.Collections.Generic;

namespace Mmu.Sms.Common.LanguageExtensions.Proxies
{
    public interface IDirectoryProxy
    {
        IReadOnlyCollection<string> GetFiles(string path);

        IReadOnlyCollection<string> GetFiles(string path, string searchPattern);
    }
}