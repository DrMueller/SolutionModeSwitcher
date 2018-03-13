namespace Mmu.Sms.DomainServices.DataAccess.Infrastructure.ExtendedStringBuilder
{
    public interface IExtendedStringBuilder
    {
        void AppendIfNotNullOrEmpty(string value);

        void AppendLine(string value, int amountOfTabs = 0);

        string Build();

        void Initialize();
    }
}