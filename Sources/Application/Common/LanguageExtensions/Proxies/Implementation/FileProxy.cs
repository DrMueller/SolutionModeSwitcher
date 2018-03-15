using System.IO;

namespace Mmu.Sms.Common.LanguageExtensions.Proxies.Implementation
{
    public class FileProxy : IFileProxy
    {
        public void Delete(string path)
        {
            File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            var result = File.ReadAllText(path);
            return result;
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}