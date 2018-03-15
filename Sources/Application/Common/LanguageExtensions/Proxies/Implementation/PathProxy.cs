﻿using System.IO;

namespace Mmu.Sms.Common.LanguageExtensions.Proxies.Implementation
{
    public class PathProxy : IPathProxy
    {
        public string ChangeExtension(string path, string extension)
        {
            return Path.ChangeExtension(path, extension);
        }

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        public string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
    }
}