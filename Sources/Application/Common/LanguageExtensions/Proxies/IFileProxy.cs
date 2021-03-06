﻿namespace Mmu.Sms.Common.LanguageExtensions.Proxies
{
    public interface IFileProxy
    {
        void Delete(string path);

        bool Exists(string path);

        string ReadAllText(string path);

        void WriteAllText(string path, string contents);
    }
}