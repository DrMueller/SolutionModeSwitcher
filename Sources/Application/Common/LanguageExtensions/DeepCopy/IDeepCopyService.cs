namespace Mmu.Sms.Common.LanguageExtensions.DeepCopy
{
    public interface IDeepCopyService
    {
        T DeepCopy<T>(T source);
    }
}